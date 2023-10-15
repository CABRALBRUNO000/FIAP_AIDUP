using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class EnqueteRepository
    {


        private readonly IMongoCollection<EnqueteModel> _enqueteCollection;


        public EnqueteRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {
            var mongoClient = new MongoClient(aidupDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(aidupDatabaseSettings.Value.TopicoDatabase);
            _enqueteCollection = mongoDatabase.GetCollection<EnqueteModel>(aidupDatabaseSettings.Value.EnqueteCollectionName);
        }

        public async Task<List<EnqueteModel>> GetAsync() =>
       await _enqueteCollection.Find(_ => true).ToListAsync();

        public async Task<EnqueteModel?> GetAsync(string id) =>
            await _enqueteCollection.Find(x => x.IdEnquete == id).FirstOrDefaultAsync();

        public async Task CreateAsync(EnqueteModel newInstituicao) =>
            await _enqueteCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, EnqueteModel updatedInstituicao) =>
            await _enqueteCollection.ReplaceOneAsync(x => x.IdEnquete == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await _enqueteCollection.DeleteOneAsync(x => x.IdEnquete == id);

    }
}
