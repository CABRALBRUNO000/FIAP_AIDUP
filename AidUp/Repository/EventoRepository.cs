using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class EventoRepository
    {


        private readonly IMongoCollection<EventoModel> _eventoCollection;


        public EventoRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {
            var mongoClient = new MongoClient(aidupDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(aidupDatabaseSettings.Value.TopicoDatabase);
            _eventoCollection = mongoDatabase.GetCollection<EventoModel>(aidupDatabaseSettings.Value.EventoCollectionName);
        }

        public async Task<List<EventoModel>> GetAsync() =>
       await _eventoCollection.Find(_ => true).ToListAsync();

        public async Task<EventoModel?> GetAsync(string id) =>
            await _eventoCollection.Find(x => x.IdEvento == id).FirstOrDefaultAsync();

        public async Task CreateAsync(EventoModel newInstituicao) =>
            await _eventoCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, EventoModel updatedInstituicao) =>
            await _eventoCollection.ReplaceOneAsync(x => x.IdEvento == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await _eventoCollection.DeleteOneAsync(x => x.IdEvento == id);

    }
}
