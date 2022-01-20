using PingPongServer.Abstractions;
using PingPongServer.Exceptions;
using PingPongServer.UIIO.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace PingPongServer.Implamentations
{
    public class ClientReplier : IClientReplier
    {
        private ServerBase _server;
        private IOutput _output;

        public ClientReplier(ServerBase server, IOutput output)
        {
            _server = server;
            _output = output;
        }

        public async Task Run(CancellationToken token)
        {
            await _server.Bind();
            while (!token.IsCancellationRequested)
            {
                _output.WriteLine("Awaiting Connection");
                await _server.Listen();
                IStreamerIO streamer = await _server.Accept();
                _output.WriteLine("Found connection");
                StreamerReply(streamer);
                await Task.Delay(500);
            }
            await _server.Close();
        }

        private async Task StreamerReply(IStreamerIO streamer)
        {
            try
            {
                string message = await streamer.Read();
                _output.WriteLine("Recieved message : " + message);
                await streamer.Write(message);
                _output.WriteLine("Sent back message : " + message);
                await streamer.Close();
            }
            catch (DisconnectedException)
            {
                _output.WriteLine("Client Disconnected");
            }
        }
    }
}