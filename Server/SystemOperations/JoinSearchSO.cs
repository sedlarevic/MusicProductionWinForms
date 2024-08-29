using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.SystemOperations
{
    public class JoinSearchSO : BaseSO
    {
        protected override void ExecuteConcreteOperation(object parameter = null)
        {
            //preko joinsearch kontrolera radi i lagano. ovde ispravljaj sve, kontroler zovi u datasource pri otvaranju forme.
            //prvi element po kom trazis
            SearchValue svDirector = new SearchValue
            {
                Type = typeof(Director).AssemblyQualifiedName,
                Parameter = "StageName",
                Value = "stef4n"
            };
            //trazis prvi element koji je vezan za tog
            BindingList<Director> dList = (BindingList<Director>)broker.Search<Director>(svDirector);
            Director d = dList.ElementAt(0);
            int directorId = d.Id;
            SearchValue svMusicVideo = new SearchValue
            {
                Type = typeof(MusicVideo).AssemblyQualifiedName,
                Parameter = "Director",
                Value = d.Id.ToString()
            };
            //uzimas sve elemente onog objekta koji treba da se prikaze pa filtriras
            BindingList<MusicVideo> mvList = (BindingList<MusicVideo>)broker.Search<MusicVideo>(svMusicVideo);
            SearchValue svAllSongs = new SearchValue
            {
                Type = typeof(Song).AssemblyQualifiedName,
                Parameter = "Name",
                Value = ""
            };
            BindingList<Song> allSongs = (BindingList<Song>)broker.Search<Song>(svAllSongs);
            BindingList<Song> songs = new BindingList<Song>();
            //filtriras
            foreach (Song s in allSongs)
            {
                foreach (MusicVideo mv in mvList)
                {
                    if (s.MusicVideo.Id == mv.Id)
                    {
                        songs.Add(s);
                    }
                }
            }

            Result = songs;
        }
    }
}
