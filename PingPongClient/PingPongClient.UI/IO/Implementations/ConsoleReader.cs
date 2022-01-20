using PingPongClient.UI.IO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.UI.IO.Implementations
{
    public class ConsoleReader : IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
