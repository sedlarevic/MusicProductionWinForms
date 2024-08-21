using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class Sender
    {

        private NetworkStream stream;
#pragma warning disable SYSLIB0011 // Type or member is obsolete
        private BinaryFormatter formatter;
#pragma warning restore SYSLIB0011 // Type or member is obsolete
        private Socket socket;

        public Sender(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Type or member is obsolete
        }

        public void Send(object argument)
        {
            try
            {
                formatter.Serialize(stream, argument);
            }
            catch (IOException)
            {
                throw new IOException("Server closed");
            }
        }

    }
}
