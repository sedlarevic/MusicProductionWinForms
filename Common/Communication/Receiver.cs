using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Common.Communication
{
    [SuppressMessage("CodeQuality", "SYSLIB0011:BinaryFormatter serialization is obsolete", Justification = "Using BinaryFormatter for compatibility reasons")]

    public class Receiver
    {

        private NetworkStream stream;
#pragma warning disable SYSLIB0011 // Type or member is obsolete
        private BinaryFormatter formatter;
#pragma warning restore SYSLIB0011 // Type or member is obsolete
        private Socket socket;

        public Receiver(Socket socket)
        {
            this.socket = socket;
            stream = new NetworkStream(socket);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Type or member is obsolete
        }

        public object Receive()
        {
            return formatter.Deserialize(stream);
        }

    }
}
