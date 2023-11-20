using Newtonsoft.Json;

namespace UnityCraft.Editor
{
    public class ToolChangeObject
    {
        [JsonProperty(PropertyName = "message_type")]
        public string MessageType { get; set; }
        
        [JsonProperty(PropertyName = "session_id")]
        public string SessionId { get; set; }
        
        [JsonProperty(PropertyName = "tool_id")]
        public string ToolId { get; set; }
    }
}