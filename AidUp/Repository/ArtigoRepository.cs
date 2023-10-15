using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class ArtigoRepository
    {
        private readonly IMongoCollection<ArtigoModel> _artigoCollection;


        public ArtigoRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {
            var mongoClient = new MongoClient(aidupDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(aidupDatabaseSettings.Value.TopicoDatabase);
            _artigoCollection = mongoDatabase.GetCollection<ArtigoModel>(aidupDatabaseSettings.Value.ArtigoCollectionName);
        }


        public async Task<List<ArtigoModel>> GetAsync() =>
       await _artigoCollection.Find(_ => true).ToListAsync();

        public async Task<ArtigoModel?> GetAsync(string id) =>
            await _artigoCollection.Find(x => x.IdArtigo == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ArtigoModel newInstituicao) =>
            await _artigoCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, ArtigoModel updatedInstituicao) =>
            await _artigoCollection.ReplaceOneAsync(x => x.IdArtigo == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await _artigoCollection.DeleteOneAsync(x => x.IdArtigo == id);

    }
}
