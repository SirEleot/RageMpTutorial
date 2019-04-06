using System;
using RAGE;

namespace Tuter
{
    public class ClientTest : Events.Script
    {
        public ClientTest()
        {
            Events.OnPlayerChat += OnPlayerChat;
            Events.Add("cl_TestEvent", OnTestEvent);
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
