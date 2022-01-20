namespace PingPongServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            var clientReplier = bootstrapper.GetClientReplier();
            clientReplier.Run();
        }
    }
}
