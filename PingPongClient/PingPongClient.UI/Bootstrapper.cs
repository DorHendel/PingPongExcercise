using PingPongClient.UI.ClientInterface.Abstractions;
using PingPongClient.UI.ClientInterface.Implementations;
using PingPongClient.UI.IO.Implementations;
using PingPongConnection;
using System.Net;
using System.Net.Sockets;

namespace PingPongClient.UI
{
    public class Bootstrapper
    {
        public IClientAction GetClientAction()
        {
            IPAddress iPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            var serverComm = new SocketServerCommunicator(new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp),
                new IPEndPoint(iPAddress, 10000));
            var clientAction = new PingPongClientAction(serverComm, new ConsoleReader(), new ConsoleWriter(), 1024);
            return clientAction;
        }
    }
}
