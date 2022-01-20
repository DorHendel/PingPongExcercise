using System.Threading.Tasks;

namespace PingPongServer.Abstractions
{
    public interface IStreamerIO
    {
        Task Write(string message);
        Task<string> Read();
        Task Close();
    }
}
