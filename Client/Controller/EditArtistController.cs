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
    public class EditArtistController
    {
        
        private static EditArtistController instance;
        public static EditArtistController Instance
        {
            get
            {
                if(instance == null)
                    instance = new EditArtistController();
                return instance;
            }
        }
        internal object EditArtist(EditValue eValue)
        {
            Response res = Communication.Instance.Edit(eValue);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                throw new ServerDisconnectedException(res.Exception.Message);
                return null;
            }
            else
            if (res.Result != null)
            {
                MessageBox.Show($"Artist successfuly edited!", "Artist successfully edited!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return res.Result;
            }
            else
            {
                Debug.Write("No song and no exception");
                return null;
            }
            

        }
    }
}
