using PingPongServer.Abstractions;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PingPongServer.Exceptions;

namespace PingPongServer.Implamentations
{
    class SocketIO : IStreamerIO
    {
        Socket _socket;

        public SocketIO(Socket socket)
        {
            _socket = socket;
        }

        public Task Close()
        {
            return new Task(() =>
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            });
        }

        public Task<string> Read()
        {
            try
            {
                if (!_socket.Connected)
                {
                    throw new DisconnectedException();
                }
                    byte[] buffer = new byte[1024];
                    _socket.Receive(buffer);
                    return new Task<string>(() => Encoding.ASCII.GetString(buffer));
            }
            catch (DisconnectedException)
            {
                Close();
                throw;
            }
        }

        public Task Write(string message)
        {
            try
            {
                if (!_socket.Connected)
                {
                    throw new DisconnectedException();
                }

                return new Task(() => _socket.Send(Encoding.ASCII.GetBytes(message)));

            }
            catch (DisconnectedException)
            {
                Close();
                throw;
            }
        }
    }
}