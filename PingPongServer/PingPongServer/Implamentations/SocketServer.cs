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

        public override Task<IStreamerIO> Accept()
        {
            return new Task<IStreamerIO>(()=> new SocketIO(_socket.Accept()));
        }

        public override Task Bind()
        {
            return new Task(()=> _socket.Bind(_iPEndPoint));
        }

        public override Task Close()
        {
            return new Task(() => 
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
            );
        }

        public override Task Listen()
        {
            return new Task(() => _socket.Listen(_maxClientNum));
        }
    }
}
