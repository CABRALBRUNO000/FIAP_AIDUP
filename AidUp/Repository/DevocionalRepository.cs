using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class DevocionalRepository
    {

        private readonly IMongoCollection<DevocionalModel> _devocionalCollection;


        public DevocionalRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {
            var mongoClient = new MongoClient(aidupDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(aidupDatabaseSettings.Value.TopicoDatabase);
            _devocionalCollection = mongoDatabase.GetCollection<DevocionalModel>(aidupDatabaseSettings.Value.DevocionalCollectionName);
        }


        public async Task<List<DevocionalModel>> GetAsync() =>
       await _devocionalCollection.Find(_ => true).ToListAsync();

        public async Task<DevocionalModel?> GetAsync(string id) =>
            await _devocionalCollection.Find(x => x.IdDevocional == id).FirstOrDefaultAsync();

        public async Task CreateAsync(DevocionalModel newInstituicao) =>
            await _devocionalCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, DevocionalModel updatedInstituicao) =>
            await _devocionalCollection.ReplaceOneAsync(x => x.IdDevocional == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await _devocionalCollection.DeleteOneAsync(x => x.IdDevocional == id);

    }
}
