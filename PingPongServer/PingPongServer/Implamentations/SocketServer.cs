using PingPongServer.Abstractions;
using PingPongServer.Implamentations;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace PingPongServer
{
    public class SocketServer : ServerBase
    {

        private Socket _socket;
        private IPEndPoint _iPEndPoint;
        private int _maxClientNum;

        public SocketServer(Socket socket, IPEndPoint iPEndPoint, int maxClientNum)
        {
            _socket = socket;
            _iPEndPoint = iPEndPoint;
            _maxClientNum = maxClientNum;
        }

        public override Task<IStreamerIO> Accept()
        {
            var accept = new Task<IStreamerIO>(()=> new SocketIO(_socket.Accept()));
            accept.Start();
            return accept;
        }

        public override Task Bind()
        {
            return Task.Run(()=> _socket.Bind(_iPEndPoint));
        }

        public override Task Close()
        {
            return Task.Run(() => 
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
            );
        }

        public override Task Listen()
        {
            return Task.Run(() => _socket.Listen(_maxClientNum));
        }
    }
}
