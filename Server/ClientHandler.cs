using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {

        private Sender sender;
        private Receiver receiver;
        private Socket socket;
        public string Username { get; set; }

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);
        }
        public void HandleRequest()
        {
            try
            {
                while (true)
                {
                    Request req = (Request)receiver.Receive();
                     Response r = ProcessRequest(req);
                    sender.Send(r);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public Response ProcessRequest(Request req) 
        {

            Response r = new Response();

            switch (req.Operation)
            {
                case Operation.Login:
                    object resultLogin = Controller.Instance.Login((dynamic)req.Argument);
                    if (resultLogin != null && resultLogin.GetType() == typeof(Exception))
                        r.Exception = (Exception)resultLogin;
                    else
                        r.Result = resultLogin;
                    break;
                case(Operation.Logout):
                    object resultLogout = Controller.Instance.Logout((MusicProducer)req.Argument);
                    if (resultLogout != null && resultLogout.GetType() == typeof(Exception))
                        r.Exception = (Exception)resultLogout;
                    else
                        r.Result = resultLogout;
                    break;
                case Operation.Add:
                    object resultAdd = Controller.Instance.Add((dynamic)req.Argument);
                    if (resultAdd != null && resultAdd.GetType() == typeof(Exception))
                        r.Exception = (Exception)resultAdd;
                    else
                        r.Result = resultAdd;
                    break;     
                case Operation.Edit:
                    object resultEdit = Controller.Instance.Edit((dynamic)req.Argument);
                    if (resultEdit != null && resultEdit.GetType() == typeof(Exception))
                        r.Exception = (Exception)resultEdit;
                    else
                        r.Result = resultEdit;
                    break;
                case Operation.Search:
                    object resultSearch = Controller.Instance.Search((dynamic)req.Argument);
                    if (resultSearch != null && resultSearch.GetType() == typeof(Exception))
                        r.Exception = (Exception)resultSearch;
                    else
                        r.Result = resultSearch;
                    break;
                case Operation.Load:
                    object resultLoad = Controller.Instance.Load((dynamic)req.Argument);
                    if (resultLoad != null && resultLoad.GetType() == typeof(Exception))
                        r.Exception = (Exception)resultLoad;
                    else
                        r.Result = resultLoad;
                    break;
            }
            
            return r;

        }

        public void CloseConnection()
        {
            socket.Close();
            
        }

    }
}
