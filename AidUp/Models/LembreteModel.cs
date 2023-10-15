using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AidUp.Models
{
    public class LembreteModel: TopicoModel
    {
        public LembreteModel()
        {
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdLembrete { get; set; }
        
        public DateTime dataAcao { get; set; }
        public bool completed { get; set; }

        public LembreteModel(string idLembrete, DateTime dataAcao, bool completed)
        {
            IdLembrete = idLembrete;
            this.dataAcao = dataAcao;
            this.completed = completed;
        }
    }
}
