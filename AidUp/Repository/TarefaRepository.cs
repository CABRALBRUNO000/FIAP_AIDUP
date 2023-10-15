using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class TarefaRepository
    {
        private readonly IMongoCollection<TarefaModel> _tarefaCollection;


        public TarefaRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {

            var mongoClient = new MongoClient(
                aidupDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                aidupDatabaseSettings.Value.TopicoDatabase);

            _tarefaCollection = mongoDatabase.GetCollection<TarefaModel>(
                aidupDatabaseSettings.Value.TarefaCollectionName);
        }


        public async Task<List<TarefaModel>> GetAsync() =>
       await _tarefaCollection.Find(_ => true).ToListAsync();

        public async Task<TarefaModel?> GetAsync(string id) =>
            await _tarefaCollection.Find(x => x.IdTarefa == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TarefaModel newInstituicao) =>
            await _tarefaCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, TarefaModel updatedInstituicao) =>
            await _tarefaCollection.ReplaceOneAsync(x => x.IdTarefa == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await _tarefaCollection.DeleteOneAsync(x => x.IdTarefa == id);

    }
}
