using System.Threading.Tasks;
using System.Threading;

namespace PingPongServer.Abstractions
{
    public interface IClientReplier
    {
        void Run(CancellationToken token);
    }
}
