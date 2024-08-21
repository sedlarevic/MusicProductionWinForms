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
    public class SearchMusicVideoController
    {

        private static SearchMusicVideoController instance;
        private List<MusicVideo> videos = new List<MusicVideo>();
        public static SearchMusicVideoController Instance
        {
            get
            {
                if (instance == null)
                    instance = new SearchMusicVideoController();
                return instance;
            }
        }
        
        internal object SearchMusicVideo(SearchValue searchValue)
        {
            Response res = Communication.Instance.Search(searchValue);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful search of music videos", "Searching music videos unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

