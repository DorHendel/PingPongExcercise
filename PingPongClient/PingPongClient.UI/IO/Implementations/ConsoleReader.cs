using PingPongClient.UI.IO.Abstractions;
using System;

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
