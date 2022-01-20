using System;

namespace PingPongClient.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            var clientAction = bootstrapper.GetClientAction();
            clientAction.Action();
            Console.ReadKey();
        }
    }
}
