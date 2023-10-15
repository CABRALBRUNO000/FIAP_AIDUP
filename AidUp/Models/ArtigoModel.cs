using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AidUp.Models
{
    public class ArtigoModel :TopicoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdArtigo { get; set; }


        public ArtigoModel(string idArtigo, string idAutor, string idInstituicao, string titulo, DateTime dataPublicacao, string conteudo, string[] tags, StatusTopico status, string urlMidia)
        {
            IdArtigo = idArtigo;
            IdAutor = idAutor;
            IdInstituicao = idInstituicao;
            Titulo = titulo;
            DataPublicacao = dataPublicacao;
            Conteudo = conteudo;
            Tags = tags;
            Status = status;
            UrlMidia = urlMidia;
        }
    }
}
