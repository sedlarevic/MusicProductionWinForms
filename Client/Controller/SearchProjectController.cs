using Common.Communication;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class SearchProjectController
    {

        private static SearchProjectController instance;
        public static SearchProjectController Instance
        {
            get
            {
                if(instance == null)
                    instance = new SearchProjectController();
                return instance;
            }
        }

        internal object SearchProject(SearchValue searchValue)
        {
            Response res = Communication.Instance.Search(searchValue);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful search of projects", "Searching projects unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                throw new ServerDisconnectedException(res.Exception.Message);
            }
            else
            if (res.Result != null)
            {
                
                return res.Result;
            }
            MessageBox.Show("Unsuccessful search of projects", "Searching projects unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
}
