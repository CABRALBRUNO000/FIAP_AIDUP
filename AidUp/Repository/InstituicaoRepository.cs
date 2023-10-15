using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class InstituicaoRepository
    {

        private readonly IMongoCollection<InstituicaoModel> _instituicaoCollection;


        public InstituicaoRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {

            var mongoClient = new MongoClient(
                aidupDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                aidupDatabaseSettings.Value.PersonaDatabase);

            _instituicaoCollection = mongoDatabase.GetCollection<InstituicaoModel>(
                aidupDatabaseSettings.Value.InstituicaoCollectionName);
        }

        public async Task<List<InstituicaoModel>> GetAsync() =>
    await _instituicaoCollection.Find(_ => true).ToListAsync();

        public async Task<InstituicaoModel?> GetAsync(string id) =>
            await _instituicaoCollection.Find(x => x.IdInstituicao == id).FirstOrDefaultAsync();

        public async Task CreateAsync(InstituicaoModel newInstituicao) =>
             await _instituicaoCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, InstituicaoModel updatedInstituicao) =>
      await _instituicaoCollection.ReplaceOneAsync(x => x.IdInstituicao == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
        await _instituicaoCollection.DeleteOneAsync(x => x.IdInstituicao == id);
    }
}
