using Client.UserControls;
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
    public class AddArtistController 
    {

        private static AddArtistController instance;
       
        private UCAddArtist addArtist;
        public UCAddArtist AddArtistForm { get { return addArtist; } set { addArtist = value; } }

        public static AddArtistController Instance
        {
            get 
            { 
                if(instance == null)
                    instance = new AddArtistController();
                return instance;
            }
        }

        

        internal void AddArtist(Artist artist)
        {
            Response res = Communication.Instance.Add(artist);
            if (res.Exception != null)
            {
                Debug.WriteLine(res.Exception.Message);
                
                MessageBox.Show("Unsuccessful add of artist", "Adding artist unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(res.Exception.Message == "Server closed")
                    throw new ServerDisconnectedException(res.Exception.Message);
                throw new Exception(res.Exception.Message);
            }
            else 
            if (res.Result != null)
            {
                MessageBox.Show($"Artist successfuly added!", "Artist successfully added!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Artist already exists!", "Adding artist unsuccessful.. Try again", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
