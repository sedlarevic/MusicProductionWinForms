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
    public class AddMusicVideoController
    {

        private static AddMusicVideoController instance;        
        public static AddMusicVideoController Instance
        {
            get
            {
                if(instance == null)
                    instance = new AddMusicVideoController();
                return instance;
            }
        }

        

        internal object AddMusicVideo(MusicVideo mv)
        {
            Response res = Communication.Instance.Add(mv);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);

                if (res.Exception.Message == "Server closed")
                {
                    MessageBox.Show("Server closed", "Adding music video unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (res.Exception.Message == "Server closed")
                        throw new ServerDisconnectedException(res.Exception.Message);
                    throw new Exception(res.Exception.Message);
                }
                return null;
            }
            else
           if (res.Result != null)
            {
                MessageBox.Show($"Music video successfuly added!", "Music video successfully added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return res.Result;
            }
            else
            {
                MessageBox.Show("Music Video already exists!", "Adding music video unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
