using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AidUp.Models
{
    public class DevocionalModel : TopicoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdDevocional { get; set; }
  
        public string Referencia { get; set; }
        public string Versículo { get; set; }
        public string Versao { get; set;}

        public DevocionalModel(string idDevocional, string referencia, string versículo, string versao)
        {
            IdDevocional = idDevocional;
            Referencia = referencia;
            Versículo = versículo;
            Versao = versao;
        }
    }
}
