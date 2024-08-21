using Common.Communication;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class SearchDirectorController
    {

        private static SearchDirectorController instance;     
        public static SearchDirectorController Instance
        {
            get
            {
                if(instance == null)
                    instance = new SearchDirectorController();
                return instance;
            }
        }
        internal object SearchDirector(SearchValue sv)
        {
            Response res = Communication.Instance.Search(sv);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful search of director", "Searching directors unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
