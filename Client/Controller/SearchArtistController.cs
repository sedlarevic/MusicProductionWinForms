using Common.Communication;
using Common.Domain;
using Common.Exceptions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class SearchArtistController
    {

        private static SearchArtistController instance;
        private List<Artist> artists = new List<Artist>();
        public static SearchArtistController Instance
        {
            get 
            {   
                if(instance == null)
                    instance = new SearchArtistController();
                return instance;
            }
        }  
        internal object SearchArtist(SearchValue searchValue)
        {
            Response res = Communication.Instance.Search(searchValue);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful search of artists", "Searching artists unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ServerDisconnectedException(res.Exception.Message);
            }
            else
            if(res.Result!=null){
                return res.Result;
            }
            return null;
        }
    }

        
}

