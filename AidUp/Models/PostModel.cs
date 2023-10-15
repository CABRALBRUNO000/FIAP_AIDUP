using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AidUp.Models
{
    public class PostModel :TopicoModel
    {
        public PostModel()
        {
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdPost { get; set; }
      
        public int NumeroVisualizacoes { get; set; }
        public int NumeroCurtidas { get; set; }

        public PostModel(string idPost, int numeroVisualizacoes, int numeroCurtidas)
        {
            IdPost = idPost;
            NumeroVisualizacoes = numeroVisualizacoes;
            NumeroCurtidas = numeroCurtidas;
        }
    }
}
