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
    public class AddSongController
    {

        private static AddSongController instance;
        
        public static AddSongController Instance
        {
            get
            {
                if(instance == null)
                    instance = new AddSongController();
                return instance;
            }
        }
        internal void AddSong(Song song)
        {
            Response res = Communication.Instance.Add(song);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);

                if (res.Exception.Message == "Server closed")
                {
                    MessageBox.Show("Server closed", "Adding song unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (res.Exception.Message == "Server closed")
                        throw new ServerDisconnectedException(res.Exception.Message);
                    throw new Exception(res.Exception.Message);
                }
               
            }
            else
           if (res.Result != null)
            {
                MessageBox.Show($"Song successfuly added!", "Song successfully added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Song already exists!", "Adding song unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


    }
}
