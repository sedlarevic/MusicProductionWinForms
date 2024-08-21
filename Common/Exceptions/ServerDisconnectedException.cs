using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    [Serializable]
    public class ServerDisconnectedException : Exception
    {
        public object Object { get; }
        public ServerDisconnectedException()
        {
        }

        public ServerDisconnectedException(string? message) : base(message)
        {
        }

        public ServerDisconnectedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
