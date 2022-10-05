using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_simple_client
{
    internal class SimpleClient
    {
        const int PORT_NO = 50000;

        static void Main(string[] args)
        {

            // IPAddress needs to be converted to a string to use function TcpClient()
            TcpClient client = new TcpClient(IPAddress.Loopback.ToString(), PORT_NO);
            NetworkStream nwStream = client.GetStream();

            while (true)
            {
                //---data to send to the server---
                Console.WriteLine("Write a message to send:");
                string textToSend = Console.ReadLine();
                if (textToSend == "exit")
                    break;
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

                //---send the text---
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);
                Console.WriteLine("Sent!\n");

            }
            client.Close();
        }
    }
}
