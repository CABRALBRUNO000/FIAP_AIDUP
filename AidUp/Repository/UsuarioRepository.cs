using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class UsuarioRepository
    {

        private readonly IMongoCollection<UsuarioModel> _usuarioCollection;


        public UsuarioRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {
            var mongoClient = new MongoClient(aidupDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(aidupDatabaseSettings.Value.PersonaDatabase);
            _usuarioCollection = mongoDatabase.GetCollection<UsuarioModel>(aidupDatabaseSettings.Value.UsuarioCollectionName);
        }


        public async Task<List<UsuarioModel>> GetAsync() =>
            await _usuarioCollection.Find(_ => true).ToListAsync();

        public async Task<UsuarioModel?> GetAsync(string id) =>
            await _usuarioCollection.Find(x => x.IdUsuario == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UsuarioModel newInstituicao) =>
            await _usuarioCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, UsuarioModel updatedInstituicao) =>
            await _usuarioCollection.ReplaceOneAsync(x => x.IdUsuario == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await _usuarioCollection.DeleteOneAsync(x => x.IdUsuario == id);

    }
}
