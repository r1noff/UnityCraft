using UnityEditor;

namespace UnityCraft.Editor
{
    public class ProjectTool : NavigationTool
    {
        public override string Name => "Project";
        protected override EditorWindow GetWindow() =>
            typeof(EditorWindow).Assembly
                .GetType("UnityEditor.ProjectBrowser")
                .GetStaticFieldValue<EditorWindow>("s_LastInteractedProjectBrowser", true);
    }
}