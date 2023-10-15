using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class ProgramacaoRepository
    {

        private readonly IMongoCollection<ProgramacaoModel> ProgramacaoCollection;


        public ProgramacaoRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {
            var mongoClient = new MongoClient(aidupDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(aidupDatabaseSettings.Value.TopicoDatabase);
            ProgramacaoCollection = mongoDatabase.GetCollection<ProgramacaoModel>(aidupDatabaseSettings.Value.ProgramacaoCollectionName);
        }


        public async Task<List<ProgramacaoModel>> GetAsync() =>
       await ProgramacaoCollection.Find(_ => true).ToListAsync();

        public async Task<ProgramacaoModel?> GetAsync(string id) =>
            await ProgramacaoCollection.Find(x => x.idProgramacao == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ProgramacaoModel newInstituicao) =>
            await ProgramacaoCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, ProgramacaoModel updatedInstituicao) =>
            await ProgramacaoCollection.ReplaceOneAsync(x => x.idProgramacao == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await ProgramacaoCollection.DeleteOneAsync(x => x.idProgramacao == id);

    }
}
