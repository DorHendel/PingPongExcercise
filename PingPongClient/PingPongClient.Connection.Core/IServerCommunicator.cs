namespace PingPongClient.Connection.Core
{
    public interface IServerCommunicator
    {
        bool TryConnect();
        byte[] Recieve(byte[] buffer);
        void Send(byte[] bytes);
        void Close();
    }
}
