using System;
using Newtonsoft.Json;

namespace UnityCraft.Editor
{
    public class CrownRootObject
    {
        [JsonProperty(PropertyName = "message_type")]
        public string MessageType { get; set; }
        
        [JsonProperty(PropertyName = "device_id")]
        public int DeviceID { get; set; }
        
        [JsonProperty(PropertyName = "unit_id")]
        public int UnitID { get; set; }
        
        [JsonProperty(PropertyName = "feature_id")]
        public int FeatureID { get; set; }
        
        [JsonProperty(PropertyName = "task_id")]
        public string TaskID { get; set; }
        
        [JsonProperty(PropertyName = "session_id")]
        public string SessionID { get; set; }
        
        [JsonProperty(PropertyName = "touch_state")]
        public int TouchState { get; set; }
        
        [JsonProperty(PropertyName = "task_options")]
        public TaskOptions TaskOptions { get; set; }
        
        [JsonProperty(PropertyName = "delta")]
        public int Delta { get; set; }
        
        [JsonProperty(PropertyName = "ratchet_delta")]
        public int RatchetDelta { get; set; }
        
        [JsonProperty(PropertyName = "time_stamp")]
        public long TimeStamp { get; set; }
    }
}