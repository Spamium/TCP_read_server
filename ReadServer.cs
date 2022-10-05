using System;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace TCP_read_server
{
    internal class ReadServer
    {
        const int PORT_NO = 50000;

        static void Main(string[] args)
        {
            Console.WriteLine("Creating tcp listener");

            // Create a listener (on our machine, at the port we defined above)
            TcpListener server = new TcpListener(IPAddress.Loopback, PORT_NO);
           

            server.Start();
            Console.WriteLine("Server start successful\n");

            while (true)
            {
                //if a connection exists, the server will accept it
                Console.WriteLine("Awating connection...");
                TcpClient client = server.AcceptTcpClient();

                // NetworkStream is one of the classes we can use
                NetworkStream ns = client.GetStream(); 

                Console.WriteLine("Got connection and sent greeting");
                Console.WriteLine("Received messages:");
                
                // repeat while we have a connection
                while (client.Connected)  
                {
                    // messages are are bytes
                    byte[] msg = new byte[1024];

                    // the method Read allows us to retrieve the message
                    ns.Read(msg, 0, msg.Length);

                    // convert from byte to string to read it as text
                    Console.WriteLine(ASCIIEncoding.ASCII.GetString(msg)); 
                }
            }

        }

    }
}
