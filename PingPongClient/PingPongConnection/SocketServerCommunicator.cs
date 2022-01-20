using PingPongClient.Connection.Core;
using System;
using System.Net;
using System.Net.Sockets;

namespace PingPongConnection
{
    public class SocketServerCommunicator : IServerCommunicator
    {
        private Socket _socket;
        private IPEndPoint iPEndPoint;

        public SocketServerCommunicator(Socket socket, IPEndPoint iPEndPoint)
        {
            _socket = socket;
            this.iPEndPoint = iPEndPoint;
        }

        public void Close()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
        }

        public byte[] Recieve(byte[] buffer)
        {
            int length = _socket.Receive(buffer);
            Array.Resize(ref buffer, length);
            return buffer;
        }

        public void Send(byte[] bytes)
        {
            _socket.Send(bytes);
        }

        public bool TryConnect()
        {
            try
            {
                _socket.Connect(iPEndPoint);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
