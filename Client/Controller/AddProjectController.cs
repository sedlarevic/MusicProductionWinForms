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
    public class AddProjectController
    {

        private static AddProjectController instance;
        public static AddProjectController Instance
        {
            get
            {
                if(instance == null)
                    instance = new AddProjectController();
                return instance;
            }
        }

        internal object AddProject(Project p)
        {
            Response res = Communication.Instance.Add(p);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);

                if (res.Exception.Message == "Server closed")
                {
                    MessageBox.Show("Server closed", "Adding project unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new ServerDisconnectedException(res.Exception.Message);  
                }                
                return null;
            }
            else
           if (res.Result != null)
            {
                MessageBox.Show($"Project successfuly added!", "Project successfully added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return res.Result;
            }
            else
            {
                MessageBox.Show("Project already exists!", "Adding project unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;

            }

        }


    }
}
