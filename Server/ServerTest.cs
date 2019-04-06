using GTANetworkAPI;
using System;

namespace Tuter
{
    public class ServerTest : Script
    {
       [ServerEvent(Event.PlayerConnected)]
       public void OnPlayerConnected(Client client)
       {
            NAPI.Util.ConsoleOutput($"Player name: {client.Name}");
            client.TriggerEvent("cl_TestEvent", "Remote event is worked");
       }

        [RemoteEvent("srv_TestEvent")]
        public void OnTestEvent(Client clien, string message)
        {
            NAPI.Util.ConsoleOutput($"Test message: {message}");
        }
    }
}
