using System;
using System.Collections.Generic;
using System.Text;

namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server svr = new Server();
            svr.Start();

            Console.ReadLine();
        }
    }
}