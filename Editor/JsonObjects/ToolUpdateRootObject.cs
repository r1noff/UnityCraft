using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnityCraft.Editor
{
    public class ToolUpdateRootObject
    {
        [JsonProperty(PropertyName = "message_type")]
        public string MessageType { get; set; }
        
        [JsonProperty(PropertyName = "session_id")]
        public string SessionID { get; set; }
        
        [JsonProperty(PropertyName = "show_overlay")]
        public string ShowOverlay { get; set; }
        
        [JsonProperty(PropertyName = "tool_id")]
        public string ToolID { get; set; }
        
        [JsonProperty(PropertyName = "tool_options")]
        public List<ToolOption> ToolOptions { get; set; }
        
        [JsonProperty(PropertyName = "play_task")]
        public string PlayTask { get; set; }
    }
}