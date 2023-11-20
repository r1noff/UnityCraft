using Newtonsoft.Json;

namespace UnityCraft.Editor
{
    public class CrownRegisterRootObject
    {
        [JsonProperty(PropertyName = "message_type")]
        public string MessageType { get; set; }
        
        [JsonProperty(PropertyName = "plugin_guid")]
        public string PluginGuid { get; set; }
        
        [JsonProperty(PropertyName = "PID")]
        public int Pid { get; set; }
        
        [JsonProperty(PropertyName = "execName")]
        public string ExecName { get; set; }
    }
}