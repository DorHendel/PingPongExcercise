using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.Abstractions
{
    public interface IStreamerIO
    {
        Task Write(string message);
        Task<string> Read();
    }
}
