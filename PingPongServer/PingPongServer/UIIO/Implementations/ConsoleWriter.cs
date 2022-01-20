using PingPongServer.UIIO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.UIIO.Implementations
{
    public class ConsoleWriter : IOutput
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
