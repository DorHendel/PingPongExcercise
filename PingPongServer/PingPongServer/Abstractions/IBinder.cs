using System.Threading.Tasks;

namespace PingPongServer.Abstractions
{
    public interface IBinder
    {
        Task Bind();
    }
}
