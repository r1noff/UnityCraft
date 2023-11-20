using UnityEditor;

namespace UnityCraft.Editor
{
    public class AnimationTool : ITool
    {
        public string Name => "Animation";
        
        public bool IsRatchet => false;

        public void HandleTurn(int delta) => 
            EditorWindow.GetWindow<AnimationWindow>().frame += delta;
    }
}