using System;

namespace PingPongClient.Connection.Core
{
    public interface IServerCommunicator
    {
        bool TryConnect();
        byte[] Recieve();
        void Send(byte[] bytes);
        void Close();
    }
}
