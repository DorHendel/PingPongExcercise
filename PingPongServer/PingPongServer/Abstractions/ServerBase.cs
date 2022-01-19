using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongServer.Abstractions
{
    public abstract class ServerBase : IListener, IBinder
    {
        public abstract Task<IStreamerIO> Accept();
        public abstract Task Bind();
        public abstract Task Listen();
        public abstract Task Close();

    }
}
