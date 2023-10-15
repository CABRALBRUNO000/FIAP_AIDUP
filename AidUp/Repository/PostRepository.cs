using AidUp.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AidUp.Repository
{
    public class PostRepository
    {

        private readonly IMongoCollection<PostModel> _postCollection;


        public PostRepository(IOptions<AidupDatabaseSettings> aidupDatabaseSettings)
        {

            var mongoClient = new MongoClient(
                aidupDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                aidupDatabaseSettings.Value.TopicoDatabase);

            _postCollection = mongoDatabase.GetCollection<PostModel>(
                aidupDatabaseSettings.Value.PostCollectionName);
        }


        public async Task<List<PostModel>> GetAsync() =>
       await _postCollection.Find(_ => true).ToListAsync();

        public async Task<PostModel?> GetAsync(string id) =>
            await _postCollection.Find(x => x.IdPost == id).FirstOrDefaultAsync();

        public async Task CreateAsync(PostModel newInstituicao) =>
            await _postCollection.InsertOneAsync(newInstituicao);

        public async Task UpdateAsync(string id, PostModel updatedInstituicao) =>
            await _postCollection.ReplaceOneAsync(x => x.IdPost == id, updatedInstituicao);

        public async Task RemoveAsync(string id) =>
            await _postCollection.DeleteOneAsync(x => x.IdPost == id);

    }
}
