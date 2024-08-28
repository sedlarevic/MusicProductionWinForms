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
    public class LoadAllDirectorsController
    {

        private static LoadAllDirectorsController instance;
        public static LoadAllDirectorsController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadAllDirectorsController();
                return instance;
            }
        }
        internal object LoadAllDirectors()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "StageName";
            sv.Value = "";
            sv.Type = typeof(Director).AssemblyQualifiedName;

            Response res = Communication.Instance.LoadAll(sv);
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
