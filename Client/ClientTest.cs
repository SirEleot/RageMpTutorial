using System;
using System.Collections.Generic;
using RAGE;

namespace Tuter
{
    public class ClientTest : Events.Script
    {
        public ClientTest()
        {
            Browser.Create();
            Events.OnPlayerChat += OnPlayerChat;
            Events.Tick += KeyHandler;
            Events.Add("cl_TestEvent", OnTestEvent);
            Events.Add("cef_TestEvent", OnCefTestEvent);
        }

        private void KeyHandler(List<Events.TickNametagData> nametags)
        {
            if (Input.IsDown(69)) {
                Chat.Output($"key 69 pressed: { DateTime.Now.ToString("ss") }");
                Browser.Open("");
            };
        }

        private void OnCefTestEvent(object[] args)
        {
            string Message = (string)args[0];
            Chat.Output(Message);
            Browser.Call($"changeText('{Message}')");
            Browser.Close();
        }

        private void OnTestEvent(object[] args)
        {
            string Message = (string) args[0];
            Chat.Output(Message);
        }

        private void OnPlayerChat(string text, Events.CancelEventArgs cancel)
        {
            Events.CallRemote("srv_TestEvent", text);
        }
    }
}
