using System;
using System.Collections.Concurrent;
using UnityEditor;
using UnityEngine;
using WebSocketSharp;

namespace UnityCraft.Editor
{
    [InitializeOnLoad]
    public static class Connection
    {
        private const string Address = "ws://localhost:10134";
        private const float ReconnectDelay = 5;

        private static readonly ConcurrentQueue<string> MessagesQueue = new();
        
        private static WebSocket _client;
        private static Messages _messages;
        private static float _reconnectionTimeStamp;
        private static int _reconnectionsCount;
        
        static Connection()
        {
            RecreateClient();
            SubscribeToEditor();
        }

        private static void RecreateClient()
        {
            _messages?.Release();
            _messages = null;
            
            _client = new WebSocket(Address);
            _client.OnOpen += OnOpen;
            _client.OnMessage += OnMessage;
            _client.Connect();
        }

        private static void OnOpen(object sender, EventArgs args)
        {
            _messages = new Messages(_client);
            _messages.Initialize();
            _messages.Register();
        }

        private static void OnMessage(object sender, MessageEventArgs args) => 
            MessagesQueue.Enqueue(args.Data);
        
        private static void SubscribeToEditor()
        {
            EditorApplication.update += OnUpdate;
            EditorApplication.quitting += UnsubscribeToEditor;
        }

        private static void UnsubscribeToEditor()
        {
            EditorApplication.update -= OnUpdate;
            EditorApplication.quitting -= UnsubscribeToEditor;
            _messages?.Release();
        }

        private static void OnUpdate()
        {
            if (_client.IsAlive)
            {
                while (MessagesQueue.TryDequeue(out var message)) 
                    _messages.Handle(message);
                
                return;
            }
            
            if (Time.realtimeSinceStartup - _reconnectionTimeStamp < ReconnectDelay)
             return;
            
            _reconnectionsCount++;
            if (_reconnectionsCount > 10)
            {
                RecreateClient();
                _reconnectionsCount = 0;
            }
            else
            {
                _client.Connect();
            }
            
            _reconnectionTimeStamp = Time.realtimeSinceStartup;
        }
    }
}