using System.Threading.Tasks;
using System.Threading;

namespace PingPongServer.Abstractions
{
    public interface IClientReplier
    {
        Task Run(CancellationToken token);
    }
}
