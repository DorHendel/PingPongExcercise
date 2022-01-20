using PingPongClient.UI.ClientInterface.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
