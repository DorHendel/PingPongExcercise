using PingPongClient.Connection.Core;
using PingPongClient.UI.ClientInterface.Abstractions;
using PingPongClient.UI.IO.Abstractions;
using System.Text;

namespace PingPongClient.UI.ClientInterface.Implementations
{
    public class PingPongClientAction : IClientAction
    {
        private IServerCommunicator _communicator;
        private IInput _input;
        private IOutput _output;
        private int _bufferLength;

        public PingPongClientAction(IServerCommunicator communicator, IInput input, IOutput output, int messageMaxLength)
        {
            _communicator = communicator;
            _input = input;
            _output = output;
            _bufferLength = messageMaxLength;
        }

        public void Action()
        {
            if (_communicator.TryConnect())
            {
                _output.WriteLine("Enter Message: ");
                string message = _input.ReadLine();
                _communicator.Send(Encoding.ASCII.GetBytes(message));
                byte[] buffer = new byte[_bufferLength];
                string reply = Encoding.ASCII.GetString(_communicator.Recieve(buffer));
                _output.WriteLine("Reply - " + reply);
                _communicator.Close();
            }
            else
            {
                _output.WriteLine("Could Not Connect To Server");
            }
        }
    }
}
