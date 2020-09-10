using System;
using System.IO;
using System.Net.Sockets;

namespace EchoClient
{
    internal class Client
    {
        public void Start()
        {
            //Klienten opretter forbindelse til server, på "localhost" og port 7.
            var socket = new TcpClient("localhost", 7);

            var sr = new StreamReader(socket.GetStream());
            var stw = new StreamWriter(socket.GetStream());

            var strSS = "Hej med dig!";
            stw.WriteLine(strSS);
            stw.Flush();

            var strRetur = sr.ReadLine();
            Console.WriteLine($"Tilbage fra Server : {strRetur}");

            socket.Close();
        }
    }
}