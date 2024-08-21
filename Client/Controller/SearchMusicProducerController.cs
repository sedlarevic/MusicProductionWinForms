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
    public class SearchMusicProducerController
    {

        private static SearchMusicProducerController instance;
        private List<MusicProducer> producers = new List<MusicProducer>();
        public static SearchMusicProducerController Instance
        {
            get
            {
                if (instance == null)
                    instance = new SearchMusicProducerController();
                return instance;
            }
        }
        internal object SearchMusicProducer(SearchValue searchValue)
        {
            Response res = Communication.Instance.Search(searchValue);
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
