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
    public class EditSongController
    {

        private static EditSongController instance;
       
        public static EditSongController Instance
        {
            get
            {
                if (instance == null)
                    instance= new EditSongController();
                return instance;
            }
        }
        public object EditSong(EditValue ev)
        {
            Response res = Communication.Instance.Edit(ev);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                if (res.Exception.Message == "Server closed")
                    throw new ServerDisconnectedException(res.Exception.Message);
                throw new Exception(res.Exception.Message);
            }
            else
            if (res.Result != null)
            {
                MessageBox.Show($"Song successfuly edited!", "Song successfully edited!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return res.Result;
            }
            else
            {               
                return null;
            }
        }
    }
}
