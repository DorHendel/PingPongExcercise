using System;
using System.Threading;

namespace PingPongServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int portNumber;
            if (!int.TryParse(args[0], out portNumber))
            {
                portNumber = 10000;
            }
            Bootstrapper bootstrapper = new Bootstrapper();
            var clientReplier = bootstrapper.GetClientReplier(portNumber);
            CancellationTokenSource tokenSource = new CancellationTokenSource();

            clientReplier.Run(tokenSource.Token);
            Console.ReadKey();
            tokenSource.Cancel();
            Console.ReadKey();
        }
    }
}
