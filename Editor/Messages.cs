using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using WebSocketSharp;

namespace UnityCraft.Editor
{
    public class Messages
    {
        private readonly CrownRegisterRootObject _registerRootObject = new()
        {
            MessageType = "register",
            PluginGuid = "4ddb3e7f-0971-4b68-a2eb-90b29fc9bbb8",
            ExecName = "Unity.exe"
        };
    
        private readonly ToolChangeObject _toolChangeObject = new() { MessageType = "tool_change" };
        private readonly Dictionary<string, Action<CrownRootObject>> _handlers;
        private readonly WebSocket _client;
    
        private string _sessionId;
        private Tools _tools;

        public Messages(WebSocket client)
        {
            _client = client;
            _handlers = new Dictionary<string, Action<CrownRootObject>>()
            {
                { "register_ack", RegisterAck },
                { "crown_turn_event", CrownTurnEvent },
            };
        }

        public void Initialize()
        {
            _tools = new Tools();
            _tools.OnToolChange += ChangeTool;
        }

        public void Release() => 
            _tools.Release();

        public void Register()
        {
            var currentProcess = Process.GetCurrentProcess();
            _registerRootObject.Pid = Convert.ToInt32(currentProcess.Id);
            var json = JsonConvert.SerializeObject(_registerRootObject);
            _client.Send(Encoding.UTF8.GetBytes(json));
        }

        public void Handle(string message)
        {
            var crownRootObject = JsonConvert.DeserializeObject<CrownRootObject>(message);
            if(_handlers.TryGetValue(crownRootObject.MessageType, out var handler))
                handler.Invoke(crownRootObject);
        }

        private void RegisterAck(CrownRootObject crownRootObject)
        {
            _sessionId = crownRootObject.SessionID;
            _tools.Initialize();
        }

        private void CrownTurnEvent(CrownRootObject crownRootObject) => 
            _tools.Current.HandleTurn(_tools.Current.IsRatchet ? crownRootObject.RatchetDelta : crownRootObject.Delta);

        private void ChangeTool()
        {
            _toolChangeObject.SessionId = _sessionId;
            _toolChangeObject.ToolId = _tools.Current.Name;
            var json = JsonConvert.SerializeObject(_toolChangeObject);
            _client.Send(json);
        }
    }
}
