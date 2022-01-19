using PingPongServer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.Implamentations
{
    class SocketIO : IStreamerIO
    {
        Socket _socket;

        public SocketIO(Socket socket)
        {
            _socket = socket;
        }

        public string Read()
        {
            byte[] buffer = new byte[1024];
            _socket.Receive(buffer);
            return Encoding.ASCII.GetString(buffer);
        }

        public void Write(string message)
        {
            _socket.Send(Encoding.ASCII.GetBytes(message));
        }
    }
}
