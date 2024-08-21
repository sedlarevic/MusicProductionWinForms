using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {

        Socket socket;
        private List<ClientHandler> clients;
        



        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clients = new List<ClientHandler>();
        }

        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));

            socket.Bind(endPoint);
            socket.Listen(5);

            Thread thread = new Thread(AcceptClient);
            thread.IsBackground = true;
            thread.Start();
            Controller.Instance.ActiveProducers.Clear();
        }

        public void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket clientSocket = socket.Accept();
                    ClientHandler handler = new ClientHandler(clientSocket);
                    clients.Add(handler);
                    Thread clientThread = new Thread(handler.HandleRequest);
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public void Stop()
        {
            foreach (ClientHandler client in clients)
            {
                client.CloseConnection();
            }
            clients.Clear();
            socket.Close();
        }

    }
}
