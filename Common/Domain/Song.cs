using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]

    public class Song : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BPM { get; set; }
        public DateTime CreationDate { get; set; }
        public SongGenre Genre { get; set; }
        public MusicProducer MusicProducer { get; set; }
        public Artist Artist { get; set; }
        public MusicVideo MusicVideo { get; set; }
        public Project Project { get; set; }

        public string TableName => "Song";

        public string Values
        {
            get
            {
                string musicVideoId=  MusicVideo!=null ? MusicVideo.Id.ToString() : "NULL";
                string projectId = Project != null ? Project.Id.ToString() : "NULL";
                return $"'{Name}',{BPM},'{string.Format("{0:yyyy-MM-dd HH:mm:ss}", CreationDate)}','{Genre.ToString()}',{MusicProducer.Id},{Artist.Id},{musicVideoId},{projectId}";
            }
        } 

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Name;
        }

    }
}
