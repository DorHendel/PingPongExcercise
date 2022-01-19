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

        public Task<string> Read()
        {
            byte[] buffer = new byte[1024];
            _socket.Receive(buffer);
            return new Task<string>(()=> Encoding.ASCII.GetString(buffer));
        }

        public Task Write(string message)
        {
            return new Task(()=>_socket.Send(Encoding.ASCII.GetBytes(message)));
        }
    }
}
