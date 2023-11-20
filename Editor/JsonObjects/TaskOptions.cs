using Newtonsoft.Json;

namespace UnityCraft.Editor
{
    public class TaskOptions
    {
        [JsonProperty(PropertyName = "current_tool")]
        public string CurrentTool { get; set; }
        
        [JsonProperty(PropertyName = "current_tool_option")]
        public string CurrentToolOption { get; set; }
    }
}