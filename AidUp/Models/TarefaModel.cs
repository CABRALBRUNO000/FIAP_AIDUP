using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AidUp.Models
{
    public class TarefaModel :TopicoModel
    {
        public TarefaModel()
        {
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //  na base o campo recebe o nome de '_id'
        public string IdTarefa { get; set; }
        public string IdResponsavel { get; set; }

        public DateTime dataConclusao { get; set; }
        public string prioridade { get; set; }
        public string etapaTrabalho { get; set; }


        public TarefaModel(string idTarefa, string idResponsavel, DateTime dataConclusao, string prioridade, string etapaTrabalho, string[] tags)
        {
            IdTarefa = idTarefa;
            IdResponsavel = idResponsavel;
            this.dataConclusao = dataConclusao;
            this.prioridade = prioridade;
            this.etapaTrabalho = etapaTrabalho;
            Tags = tags;
        }
    }
}
