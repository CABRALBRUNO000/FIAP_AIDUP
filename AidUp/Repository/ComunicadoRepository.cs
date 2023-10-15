using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class ComunicadoRepository
    {
        private readonly IMongoCollection<ComunicadoModel> _comunicadoCollection;


        public ComunicadoRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {
            var mongoClient = new MongoClient(aidupDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(aidupDatabaseSettings.Value.TopicoDatabase);
            _comunicadoCollection = mongoDatabase.GetCollection<ComunicadoModel>(aidupDatabaseSettings.Value.ComunicadoCollectionName);
        }


        public async Task<List<ComunicadoModel>> GetAsync() =>
       await _comunicadoCollection.Find(_ => true).ToListAsync();

        public async Task<ComunicadoModel?> GetAsync(string id) =>
            await _comunicadoCollection.Find(x => x.IdComunicado == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ComunicadoModel newInstituicao) =>
            await _comunicadoCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, ComunicadoModel updatedInstituicao) =>
            await _comunicadoCollection.ReplaceOneAsync(x => x.IdComunicado == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await _comunicadoCollection.DeleteOneAsync(x => x.IdComunicado == id);

    }
}
