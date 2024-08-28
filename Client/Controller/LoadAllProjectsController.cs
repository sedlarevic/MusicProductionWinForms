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
    public class LoadAllProjectsController
    {

        private static LoadAllProjectsController instance;
        public static LoadAllProjectsController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadAllProjectsController();
                return instance;
            }
        }

        internal object LoadAllProjects()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "Name";
            sv.Value = "";
            sv.Type = typeof(Project).AssemblyQualifiedName;
            Response res = Communication.Instance.LoadAll(sv);
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
