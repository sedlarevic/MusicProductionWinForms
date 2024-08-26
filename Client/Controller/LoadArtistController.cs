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
    public class LoadArtistController
    {

        private static LoadArtistController instance;
        public static LoadArtistController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadArtistController();
                return instance;
            }
        }
        internal object LoadArtist(SearchValue searchValue)
        {
            Response res = Communication.Instance.Load(searchValue);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful load of artist", "Load of artist unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ServerDisconnectedException(res.Exception.Message);
            }
            else
            if (res.Result != null)
            {
                BindingList<Artist> a = (BindingList<Artist>)res.Result; 
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
