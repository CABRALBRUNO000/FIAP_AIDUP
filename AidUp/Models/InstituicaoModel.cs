using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace AidUp.Models
{
    public class InstituicaoModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdInstituicao { get; set; }

        
        [JsonProperty("nome")]
        public string Nome { get; set; }

          [JsonProperty("email")]
        public string Email { get; set; }

          [JsonProperty("telefone")]
        public string Telefone { get; set; }

          [JsonProperty("endereco")]
        public EnderecoModel Endereco { get; set; }

          [JsonProperty("dataFundacao")]
        public DateTime DataFundacao { get; set; }

          [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

          [JsonProperty("tipoInstituicao")]
        public TipoInstituicaoEnum TipoInstituicao { get; set; }

          [JsonProperty("idRepresentante")]
        public string IdRepresentante { get; set; }

    }
    public enum TipoInstituicaoEnum
    {
        [JsonProperty("EMPRESA")]
        EMPRESA,

        [JsonProperty("IGREJA")]
        IGREJA
    }
}

