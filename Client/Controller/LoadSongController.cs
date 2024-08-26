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
    public class LoadSongController
    {

        private static LoadSongController instance;
        
        public static LoadSongController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadSongController();
                return instance;
            }
        }
        internal object LoadSong(SearchValue searchValue)
        {
            Response res = Communication.Instance.Load(searchValue);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful load of song", "Load of song unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ServerDisconnectedException(res.Exception.Message);
            }
            else
            if (res.Result != null)
            {
                BindingList<Song> a = (BindingList<Song>)res.Result;
                if (a != null && a.Count == 1)
                {
                    return a.ElementAt(0);
                }
                return null;
            }
            return null;
        }

    }
}
