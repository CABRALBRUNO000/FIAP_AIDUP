using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AidUp.Models
{
    public class EnqueteModel: TopicoModel
    {
        public EnqueteModel()
        {
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdEnquete { get; set; }

        public List<OpcaoResposta> Opcoes { get; set; }
        public bool PermitirMultiplasRespostas { get; set; }
        public DateTime DataInicio { get; }
        public DateTime DataFim { get; set; }


        public EnqueteModel(string idEnquete, string idAutor, string idInstituicao, string titulo, string descricao, List<OpcaoResposta> opcoes, bool permitirMultiplasRespostas, DateTime dataInicio, DateTime dataFim, string urlMidia)
        {
            IdEnquete = idEnquete;
            IdAutor = idAutor;
            IdInstituicao = idInstituicao;
            Titulo = titulo;
            Descricao = descricao;
            Opcoes = opcoes;
            PermitirMultiplasRespostas = permitirMultiplasRespostas;
            DataInicio = dataInicio;
            DataFim = dataFim;
            UrlMidia = urlMidia;
        }
    }

    public class OpcaoResposta
    {
        public int id { get; set; }
        public string texto { get; set; }
        public int nrVoto { get; set; }

     
    }

}
