using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    [Serializable]
    public class Project : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public Artist Artist { get; set; }
        public MusicProducer MusicProducer { get; set; }

        public string TableName => "Project";

        public string Values => $"'{Name}','{Description}','{string.Format("{0:yyyy-MM-dd HH:mm:ss}", CreationDate)}',{Artist.Id},{MusicProducer.Id}";

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
