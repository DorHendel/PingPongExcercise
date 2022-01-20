using PingPongClient.UI.IO.Abstractions;
using System;

namespace PingPongClient.UI.IO.Implementations
{
    public class ConsoleWriter : IOutput
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
