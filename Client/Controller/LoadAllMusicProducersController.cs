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
    public class LoadAllMusicProducersController
    {

        private static LoadAllMusicProducersController instance;
        private List<MusicProducer> producers = new List<MusicProducer>();
        public static LoadAllMusicProducersController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadAllMusicProducersController();
                return instance;
            }
        }
        internal object LoadAllMusicProducers()
        {
            SearchValue sv = new SearchValue()
            {
                Parameter = "stageName",
                Value = "",
                Type = typeof(MusicProducer).AssemblyQualifiedName
            };

            Response res = Communication.Instance.LoadAll(sv);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful search of music producers", "Searching music producers unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
