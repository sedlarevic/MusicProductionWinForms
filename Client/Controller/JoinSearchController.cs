using Common.Communication;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class JoinSearchController
    {

        private static JoinSearchController instance;
        
        public static JoinSearchController Instance
        {
            get
            {
                if (instance == null)
                    instance = new JoinSearchController();
                return instance;
            }
        }
        internal object JoinSearch()
        {
            Response res = Communication.Instance.JoinSearch();
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful search", "Searching artists unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ServerDisconnectedException(res.Exception.Message);
            }
            else
            if (res.Result != null)
            {
                return res.Result;
            }
            return null;
        }

    }
}
