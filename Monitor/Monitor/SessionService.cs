namespace Monitor
{
    using MongoDB.Driver;
    using System;

    public class SessionService
    {
        public readonly IMongoCollection<Session> sessionCollection;

        public SessionService()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");

            var mongoDatabase = mongoClient.GetDatabase("SessionStore");

            sessionCollection = mongoDatabase.GetCollection<Session>("Sessions");
        }

        public async Task<List<Session>> GetAsync() =>
            await sessionCollection.Find(_ => true).ToListAsync();

        public async Task<Session?> GetAsync(Guid id) =>
            await sessionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Session newBook) =>
            await sessionCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(Guid id, Session updatedBook) =>
            await sessionCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(Guid id) =>
            await sessionCollection.DeleteOneAsync(x => x.Id == id);
    }
}
