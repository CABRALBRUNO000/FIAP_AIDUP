using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Globalization;

namespace AidUp.Models
{
    public class EventoModel: TopicoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdEvento { get; set; }

        public Evento? Evento { get; set; }

        public EventoModel() { }

        public EventoModel(string idAutor, string idInstituicao, string urlMidia, StatusTopico status, DateTime? dataAtualizacao, Evento? evento)
        {
            IdAutor = idAutor;
            IdInstituicao = idInstituicao;
            UrlMidia = urlMidia;
            Status = status;
        
            DataAtualizacao = dataAtualizacao;
            Evento = evento;
        }
    }

    public class Evento
    {
        public string TituloEvento { get; set; }
        public DateTime Data { get; set; }
        public string Local { get; set; }
        public string Descricao { get; set; }
    }


}


//{
//    "nome": "Conferência de Tecnologia",
//      "data": "2022-05-20",
//      "local": "Centro de Convenções",
//      "descricao": "Conferência anual de tecnologia com palestras e workshops."
//    },