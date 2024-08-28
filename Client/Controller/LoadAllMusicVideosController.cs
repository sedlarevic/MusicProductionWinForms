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
    public class LoadAllMusicVideosController
    {

        private static LoadAllMusicVideosController instance;
        private List<MusicVideo> videos = new List<MusicVideo>();
        public static LoadAllMusicVideosController Instance
        {
            get
            {
                if (instance == null)
                    instance = new LoadAllMusicVideosController();
                return instance;
            }
        }

        internal object LoadAllMusicVideos()
        {
            SearchValue sv = new SearchValue()
            {
                Type = typeof(MusicVideo).AssemblyQualifiedName,
                Parameter = "Name",
                Value = ""
            };
            Response res = Communication.Instance.LoadAll(sv);
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
