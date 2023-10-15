using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class LembreteRepository
    {


        private readonly IMongoCollection<LembreteModel> _lembreteCollection;


        public LembreteRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {

            var mongoClient = new MongoClient(
                aidupDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                aidupDatabaseSettings.Value.TopicoDatabase);

            _lembreteCollection = mongoDatabase.GetCollection<LembreteModel>(
                aidupDatabaseSettings.Value.LembreteCollectionName);
        }

        public async Task<List<LembreteModel>> GetAsync() =>
       await _lembreteCollection.Find(_ => true).ToListAsync();

        public async Task<LembreteModel?> GetAsync(string id) =>
            await _lembreteCollection.Find(x => x.IdLembrete == id).FirstOrDefaultAsync();

        public async Task CreateAsync(LembreteModel newInstituicao) =>
            await _lembreteCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, LembreteModel updatedInstituicao) =>
            await _lembreteCollection.ReplaceOneAsync(x => x.IdLembrete == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await _lembreteCollection.DeleteOneAsync(x => x.IdLembrete == id);


    }
}
