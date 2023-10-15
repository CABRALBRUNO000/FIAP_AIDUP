using Amazon.Runtime.Documents;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AidUp.Models
{
    public class ProgramacaoModel :TopicoModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string idProgramacao { get; set; }    

        public List<Evento> Eventos { get; set; }

        public ProgramacaoModel() { }

        public ProgramacaoModel(string idProgramacao, List<Evento> eventos)
        {
            this.idProgramacao = idProgramacao;
            Eventos = eventos;
        }
    }
}
