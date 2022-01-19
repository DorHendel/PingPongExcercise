using System.Threading.Tasks;

namespace PingPongServer.Abstractions
{
    public interface IListener
    {
        Task Listen();
        Task<IStreamerIO> Accept();
    }
}
