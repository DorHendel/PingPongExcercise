using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.UI.IO.Abstractions
{
    public interface IOutput
    {
        void WriteLine(string line);
    }
}
