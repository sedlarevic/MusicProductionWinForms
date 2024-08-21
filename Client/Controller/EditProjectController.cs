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
    public class EditProjectController
    {

        private static EditProjectController instance;
        public static EditProjectController Instance
        {
            get
            {
                if (instance == null)
                    instance = new EditProjectController();
                return instance;
            }
        }
        public object EditProject(EditValue ev)
        {
            Response res = Communication.Instance.Edit(ev);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                throw new ServerDisconnectedException(res.Exception.Message);
                return null;
            }
            else
            if (res.Result != null)
            {
                MessageBox.Show($"Project successfuly edited!", "Project successfully edited!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return res.Result;
            }
            else
            {
                Debug.Write("No song and no exception");
                return null;
            }
        }

    }
}
