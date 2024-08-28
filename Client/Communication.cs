using Client.Controller;
using Common.Communication;
using Common.Domain;
using Common.Exceptions;
using Microsoft.VisualBasic.ApplicationServices;
using System.Buffers;
using System.Net.Sockets;

namespace Client
{
    public class Communication
    {

        Receiver receiver;
        Sender sender;
        Socket socket;
        private static Communication instance;
        public static Communication Instance
        {
            get
            {
                if (instance == null)
                    instance = new Communication();
                return instance;
            }
        }
        public void Connect()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0.0.1", 1337);
                sender = new Sender(socket);
                receiver = new Receiver(socket);
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Unable to connect to the server, server probably not running.");
                sender = null;
                receiver = null;
                socket = null;
                throw new SocketException();
                
            }
                
            
                
        }
        // ################################################################
        internal Response Login(LoginValue<MusicProducer> loginValue)
        {
            Request req = new Request
            {
                Argument = loginValue,
                Operation = Operation.Login
            };
            Response res = new Response();
            try
            {
                sender.Send(req);
                res = (Response)receiver.Receive();
            }
            catch (Exception e)
            {
                res.Exception = e;
                throw new ServerDisconnectedException("Server closed");
                  
            }
            return res;
        }
        internal Response Logout(MusicProducer musicProducer)
        {
            Request req = new Request()
            {
                Operation = Operation.Logout,
                Argument = musicProducer
            };
            Response res = new Response();
            try
            {
                sender.Send(req);
                res = (Response)receiver.Receive();
                if (res.Exception != null)
                {
                    throw new ServerDisconnectedException("Server closed");
                }
            }
            catch (Exception ex)
            {
                res.Exception = ex;
            }
           
            return res;
        }
        internal Response Add(object parameter)
        {
            Request req = new Request()
            {
                Operation = Operation.Add,
                Argument = parameter
            };
            Response res = new Response();
            try
            {
                sender.Send(req);
                res = (Response)receiver.Receive();
                if (res.Exception != null)
                {
                    throw new ServerDisconnectedException("Server closed");
                }
            }
            catch (Exception ex)
            {
                res.Exception = ex;
                
            }
            return res;
        }
        internal Response Edit(EditValue editValue)
        {
            Request req = new Request()
            {
                Operation = Operation.Edit,
                Argument = editValue
            };
            Response res = new Response();
            try
            {
                sender.Send(req);
                res = (Response)receiver.Receive();

                if (res.Exception != null)
                {
                    throw new ServerDisconnectedException("Server closed");
                }
            }
            catch (Exception ex)
            {
                res.Exception = ex;
                
            }
            return res;
        }
        internal Response Search(SearchValue searchValue)
        {
            Request req = new Request()
            {
                Operation = Operation.Search,
                Argument = searchValue
            };
            Response res = new Response();
            try
            {
                sender.Send(req);
                res = (Response)receiver.Receive();

                if (res.Exception != null)
                {
                    throw new ServerDisconnectedException("Server closed");
                }
            }
            catch (Exception ex)
            {
                
                res.Exception=ex;
            }
            return res;
        }
        internal Response Load(SearchValue searchValue)
        {
            Request req = new Request()
            {
                Operation = Operation.Load,
                Argument = searchValue
            };
            Response res = new Response();
            try
            {
                sender.Send(req);
                res = (Response)receiver.Receive();

                if (res.Exception != null)
                {
                    throw new ServerDisconnectedException("Server closed");
                }
            }
            catch (Exception ex)
            {

                res.Exception = ex;
            }
            return res;
        }
        internal Response LoadAll(SearchValue searchValue)
        {
            Request req = new Request()
            {
                Operation = Operation.LoadAll,
                Argument = searchValue
            };
            Response res = new Response();
            try
            {
                sender.Send(req);
                res = (Response)receiver.Receive();

                if (res.Exception != null)
                {
                    throw new ServerDisconnectedException("Server closed");
                }
            }
            catch (Exception ex)
            {

                res.Exception = ex;
            }
            return res;
        }
        // ################################################################
    }
}
