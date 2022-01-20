using PingPongServer.Abstractions;
using PingPongServer.Implamentations;
using PingPongServer.UIIO.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer
{
    public class Bootstrapper
    {
        public IClientReplier GetClientReplier(int portNumber)
        {
            IPAddress iPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            var server = new SocketServer(new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp), new IPEndPoint(iPAddress, portNumber), 10);
            var clientReplier = new ClientReplier(server, new ConsoleWriter());
            return clientReplier;
        }
    }
}
