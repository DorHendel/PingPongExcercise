using System;
using System.Threading;

namespace PingPongServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            var clientReplier = bootstrapper.GetClientReplier();
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            clientReplier.Run(tokenSource.Token);
            Console.ReadKey();
            tokenSource.Cancel();
            Console.ReadKey();
        }
    }
}
