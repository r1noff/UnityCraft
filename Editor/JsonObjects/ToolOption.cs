using Newtonsoft.Json;

namespace UnityCraft.Editor
{
    public class ToolOption
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}