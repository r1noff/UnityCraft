using UnityEditor;

namespace UnityCraft.Editor
{
    public class HierarchyTool : NavigationTool
    {
        public override string Name => "Hierarchy";

        protected override EditorWindow GetWindow() =>
            typeof(EditorWindow).Assembly
                .GetType("UnityEditor.SceneHierarchyWindow")
                .GetStaticFieldValue<EditorWindow>("s_LastInteractedHierarchy", false);
    }
}