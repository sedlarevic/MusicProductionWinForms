using Common.Communication;
using Common.Domain;
using Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controller
{
    public class LoadAllArtistsController
    {

        private static LoadAllArtistsController instance;
        private List<Artist> artists = new List<Artist>();
        public static LoadAllArtistsController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadAllArtistsController();
                return instance;
            }
        }
        internal object LoadAllArtists()
        {

            SearchValue searchValue = new SearchValue()
            {
                Type = typeof(Artist).AssemblyQualifiedName,
                Value = "",
                Parameter = "StageName"
            };
            Response res = Communication.Instance.LoadAll(searchValue);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                MessageBox.Show("Unsuccessful search of artists", "Searching artists unsuccessful..", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
