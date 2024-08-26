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
    public class LoadProjectController
    {

        private static LoadProjectController instance;
        public static LoadProjectController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadProjectController();
                return instance;
            }
        }

        internal object LoadProject(SearchValue searchValue)
        {
            Response res = Communication.Instance.Load(searchValue);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful load of project", "Load of project unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ServerDisconnectedException(res.Exception.Message);
            }
            else
            if (res.Result != null)
            {
                BindingList<Project> a = (BindingList<Project>)res.Result;
                if (a != null && a.Count == 1)
                {
                    return a.ElementAt(0);
                }
                return null;
            }
            MessageBox.Show("Unsuccessful load of project", "Load of project unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

    }
}
