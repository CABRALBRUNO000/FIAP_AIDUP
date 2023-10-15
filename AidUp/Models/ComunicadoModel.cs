using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AidUp.Models
{
    public class ComunicadoModel: TopicoModel
    {
        public ComunicadoModel()
        {
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdComunicado { get; set; }
        public TipoComunicado Tipo { get; set; }

      

        public ComunicadoModel(string idComunicado, string idAutor, string idInstituicao, string urlMidia, string titulo, TipoComunicado tipo, StatusTopico status)
        {
            IdComunicado = idComunicado;
            IdAutor = idAutor;
            IdInstituicao = idInstituicao;
            UrlMidia = urlMidia;
            Titulo = titulo;

            Tipo = tipo;
            this.Status = status;
        }
    }

     public enum TipoComunicado
    {
        Pastoral, 
        Padrao,
        Especial,
        Ministerial, 
        Falecimento, 
        Institucional,

    }



}
