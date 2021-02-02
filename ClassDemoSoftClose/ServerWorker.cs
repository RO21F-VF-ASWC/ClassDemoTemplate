using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ClassDemoSoftClose
{
    public class ServerWorker
    {
        private const int PORT = 7;
        private bool STOP = false;
        private List<Task> tasks = new List<Task>();
        
        public ServerWorker()
        {
        }

        public void Start()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, PORT);
            listener.Start();
            Console.WriteLine("Server started");

            Task.Run(StopServer); // starter stop server
            Console.WriteLine("Stop server started");

            while (!STOP)
            {
                if (listener.Pending())
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Client incoming");
                    Console.WriteLine($"remote (ip,port) = ({client.Client.RemoteEndPoint})");
                    tasks.Add(Task.Run(() =>
                        {
                            TcpClient tmpClient = client;
                            DoOneClient(client);
                        }
                    ));
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Server Stopped");
        }

        private void DoOneClient(TcpClient sock)
        {
            using (StreamReader sr = new StreamReader(sock.GetStream()))
            using(StreamWriter sw = new StreamWriter(sock.GetStream()))
            {
                sw.AutoFlush = true;
                Console.WriteLine("Handle one client");

                // simple echo
                String s = sr.ReadLine();
                sw.WriteLine(s);
            }
            

        }

        private void StopServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, PORT+1);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            // todo check at bruger er ok 

            STOP = true;
        }
    }
}