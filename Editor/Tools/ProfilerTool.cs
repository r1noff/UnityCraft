using UnityEditor;

namespace UnityCraft.Editor
{
    public class ProfilerTool : ITool
    {
        public string Name => "Profiler";    
        
        public bool IsRatchet => false;
        
        public void HandleTurn(int delta)
        {
            var profilerWindow = EditorWindow.GetWindow<ProfilerWindow>();
            if(profilerWindow.lastAvailableFrameIndex == -1 ||
                profilerWindow.selectedFrameIndex + delta > profilerWindow.lastAvailableFrameIndex ||
                profilerWindow.selectedFrameIndex + delta < profilerWindow.firstAvailableFrameIndex)
                return;
            
            profilerWindow.selectedFrameIndex += delta;
        }
    }
}