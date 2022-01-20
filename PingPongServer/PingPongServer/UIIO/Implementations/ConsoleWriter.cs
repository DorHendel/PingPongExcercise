using PingPongServer.UIIO.Abstractions;
using System;

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
