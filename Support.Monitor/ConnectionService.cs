namespace Monitor
{
    using MongoDB.Driver;
    using System;

    public class ConnectionService
    {
        public readonly IMongoCollection<Connection> sessionCollection;

        public ConnectionService()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");

            var mongoDatabase = mongoClient.GetDatabase("SessionStore");

            sessionCollection = mongoDatabase.GetCollection<Connection>("Sessions");
        }

        public async Task<List<Connection>> GetAsync() =>
            await sessionCollection.Find(_ => true).ToListAsync();

        public async Task<Connection?> GetAsync(Guid id) =>
            await sessionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Connection newBook) =>
            await sessionCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(Guid id, Connection updatedBook) =>
            await sessionCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(Guid id) =>
            await sessionCollection.DeleteOneAsync(x => x.Id == id);
    }
}
