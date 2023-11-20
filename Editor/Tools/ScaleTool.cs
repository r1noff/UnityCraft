using UnityEditor;
using UnityEngine;

namespace UnityCraft.Editor
{
    public class ScaleTool : ITool
    {
        public string Name => "Scale";
        
        public bool IsRatchet => false;
        
        public void HandleTurn(int delta)
        {
            foreach(var transform in Selection.transforms) 
                transform.localScale += Vector3.one * delta * 0.01f;
        }
    }
}