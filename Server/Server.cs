using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    public class Server
    {
        public void Start()
        {
            //opret server
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();

            while (true)
            {
                //Venter på at klienten skal lave et opkld. 
                TcpClient socket = server.AcceptTcpClient();
                DoClient(socket);
            }
            //socket.Close();
        }

        private void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter stw = new StreamWriter(ns);


            //Læser tekst fra klienten 
            String str = sr.ReadLine();
            Console.WriteLine($"Serverinput: {str}");
            stw.WriteLine("WordCount: " + WordCount(str));


            //Skriver tilbage fra klienten.
            String UpperStr = str.ToUpper();
            stw.WriteLine(UpperStr);
            stw.Flush(); //Tømmer buffer.
        }

        //WordCount, tæller antal ord, som sendes til server, og giver antal ord tilbage med tal.
        public int WordCount(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] strList = input.Split();

                return strList.Length;
            }

            return 0;

        }
    }
}