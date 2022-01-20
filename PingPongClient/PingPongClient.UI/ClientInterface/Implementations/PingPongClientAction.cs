using PingPongClient.Connection.Core;
using PingPongClient.UI.ClientInterface.Abstractions;
using PingPongClient.UI.IO.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongClient.UI.ClientInterface.Implementations
{
    public class PingPongClientAction : IClientAction
    {
        IServerCommunicator _communicator;
        IInput _input;
        IOutput _output;

        public PingPongClientAction(IServerCommunicator communicator, IInput input, IOutput output)
        {
            _communicator = communicator;
            _input = input;
            _output = output;
        }

        public void Action()
        {
            if (_communicator.TryConnect())
            {
                _output.WriteLine("Enter Message: ");
                string message = _input.ReadLine();
                _communicator.Send(Encoding.ASCII.GetBytes(message));
                string reply = Encoding.ASCII.GetString(_communicator.Recieve());
                _output.WriteLine("reply - " + reply);
                _communicator.Close();
            }
            else
            {
                _output.WriteLine("Could Not Connect To Server");
            }
        }
    }
}
