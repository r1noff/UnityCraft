using UnityEditor;
using UnityEngine;

namespace UnityCraft.Editor
{
    public abstract class NavigationTool : ITool
    {
        public abstract string Name { get; }
        
        public bool IsRatchet => true;

        private readonly Event _event = new() { type = EventType.KeyDown };

        public void HandleTurn(int delta)
        {
            if(delta == 0)
                return;

            var window = GetWindow();
            if(window)
            {
                _event.keyCode = delta > 0 ? KeyCode.DownArrow : KeyCode.UpArrow;
                window.SendEvent(_event);
            }
        }

        protected abstract EditorWindow GetWindow();
    }
}