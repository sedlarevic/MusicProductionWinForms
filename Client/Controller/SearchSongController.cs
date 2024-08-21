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
    public class SearchSongController
    {

        private static SearchSongController instance;
        private List<Song> songs = new List<Song>();
        public static SearchSongController Instance
        {
            get
            {
                if (instance == null)
                    instance = new SearchSongController();
                return instance;
            }
        }
        internal object SearchSong(SearchValue searchValue)
        {
            Response res = Communication.Instance.Search(searchValue);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful search of song", "Searching songs unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
