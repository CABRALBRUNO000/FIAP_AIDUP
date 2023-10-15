using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace AidUp.Models
{
    public class UsuarioModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdUsuario { get; set; }

       
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }    
        
        [JsonProperty("tipoUsuario")]
        public TipoUsuarioEnum TipoUsuario { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        
        
        [JsonProperty("urlImagem")]
        public string UrlImagem { get; set; }



        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("datadenascimento")]
        public DateTime DataDeNascimento { get; set; }

        [JsonProperty("endereco")]
        public EnderecoModel Endereco { get; set; }

        [JsonProperty("instituicoes")]
        public List<Instituicoes> Instituicoes { get; set; }
    }


    public class Instituicoes
    {
        [JsonProperty("idInstituicao")]
        public string IdInstituicao { get; set; }

        [JsonProperty("funcao")]
        public FuncaoEnum Funcao { get; set; }

        [JsonProperty("dataInscricao")]
        public DateTime DataInscricao { get; set; }

        [JsonProperty("instituicaoPadrao")]
        public bool InstituicaoPadrao { get; set; }
    }

    public enum FuncaoEnum
    {
        CEO,
        PRESIDENTE,
        DIRETOR,
        GERENTE,
        COORDENADOR,
        ANALISTA
    }
    public enum TipoUsuarioEnum
    {
        MEMBRO,
        VISITANTE    
    }
}
