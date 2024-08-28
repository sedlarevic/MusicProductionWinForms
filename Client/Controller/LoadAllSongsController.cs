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
    public class LoadAllSongsController
    {

        private static LoadAllSongsController instance;
        private List<Song> songs = new List<Song>();
        public static LoadAllSongsController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadAllSongsController();
                return instance;
            }
        }
        internal object LoadAllSongs()
        {
            SearchValue sv = new SearchValue();
            sv.Parameter = "Name";
            sv.Value = "";
            sv.Type = typeof(Song).AssemblyQualifiedName;
            Response res = Communication.Instance.Search(sv);
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
