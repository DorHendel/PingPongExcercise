using System.Threading.Tasks;

namespace PingPongServer.Abstractions
{
    public interface IConnectable
    {
        Task Connect();
    }
}
