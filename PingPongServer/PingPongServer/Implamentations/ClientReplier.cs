using PingPongServer.Abstractions;
using PingPongServer.Exceptions;
using PingPongServer.UIIO.Abstractions;
using System;
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

        public async void Run(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await _server.Listen();
                _output.WriteLine("Awaiting Connection");
                IStreamerIO streamer = await _server.Accept();
                _output.WriteLine("Found connection");
                StreamerReply(streamer, token);
                await Task.Delay(500);
            }
            await _server.Close();
        }

        private async Task StreamerReply(IStreamerIO streamer, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    string message = await streamer.Read();
                    _output.WriteLine("Recieved message : " + message);
                    await streamer.Write(message);
                    _output.WriteLine("Sent back message : " + message);
                    await Task.Delay(500);
                }
                await streamer.Close();
            }
            catch(DisconnectedException)
            {
                _output.WriteLine("Client Disconnected");
            }
        }
    }
}