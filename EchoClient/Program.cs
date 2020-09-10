using System;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var cli = new Client();
            cli.Start();

            Console.ReadLine();
        }
    }
}