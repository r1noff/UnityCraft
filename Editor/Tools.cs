using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityCraft.Editor
{
    public class Tools
    {
        public event Action OnToolChange;

        private readonly RaycastHit[] _hits = new RaycastHit[10];
        private readonly ScaleTool _scaleTool = new();
        private readonly ProfilerTool _profilerTool = new();
        private readonly AnimationTool _animationTool = new();
        private readonly ProjectTool _projectTool = new();
        private readonly HierarchyTool _hierarchyTool = new();

        private AnimationWindow _animationWindow;
        private int _skippedFrames;
        private bool _sceneViewMousePressed;
        
        public ITool Current { get; private set; }

        public void Initialize()
        {
            Current = _hierarchyTool;
            OnToolChange?.Invoke();
            EditorApplication.update += OnUpdate;
            SceneView.duringSceneGui += OnSceneGUI;
        }

        public void Release()
        {
            if(Current == null)
                return;
            
            EditorApplication.update -= OnUpdate;
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        private void OnUpdate()
        {
            if(_animationWindow == null && EditorWindow.HasOpenInstances<AnimationWindow>())
                _animationWindow = EditorWindow.GetWindow<AnimationWindow>();
            
            var tool = SelectTool();
            if(tool != Current)
            {
                Current = tool;
                OnToolChange?.Invoke();
            }
        }

        private void OnSceneGUI(SceneView view)
        {
            if(Event.current == null) 
                return;
            
            switch(Event.current.type)
            {
                case EventType.MouseDown:
                {
                    var ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                    if(Physics.RaycastNonAlloc(ray, _hits, 100f) > 0)
                        foreach(var hit in _hits)
                            if(Selection.transforms.Contains(hit.transform))
                            {
                                _sceneViewMousePressed = true;
                                break;
                            }
                    break;
                }
                case EventType.MouseLeaveWindow:
                case EventType.MouseUp: 
                    _sceneViewMousePressed = false; 
                    break;
            }
        }

        private ITool SelectTool()
        {
            if(_sceneViewMousePressed)
                return _scaleTool;
            
            if(EditorWindow.mouseOverWindow is ProfilerWindow)
                return _profilerTool;
            
            if(_animationWindow != null && _animationWindow.hasFocus && _animationWindow.animationClip != null)
                return _animationTool;
            
            if(Selection.activeObject && AssetDatabase.Contains(Selection.activeObject))
                return _projectTool;
            
            return _hierarchyTool;
        }
    }
}