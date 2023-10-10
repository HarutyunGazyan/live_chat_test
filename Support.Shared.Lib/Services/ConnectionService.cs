namespace Shared.Library.Services
{
    using MongoDB.Driver;
    using System;
    using Shared.Library.Services.Models;
    using Microsoft.Extensions.Options;
    using Support.Shared.Lib.Options;

    public class ConnectionService
    {
        public readonly IMongoCollection<SessionConnection> sessionCollection;

        public ConnectionService(IOptions<MongoDbOptions> options)
        {
            var mongoClient = new MongoClient(options.Value.Connection);

            var mongoDatabase = mongoClient.GetDatabase(options.Value.Name);

            sessionCollection = mongoDatabase.GetCollection<SessionConnection>(options.Value.Collection);
        }

        public async Task<List<SessionConnection>> GetAsync() =>
            await sessionCollection.Find(_ => true).ToListAsync();

        public async Task<SessionConnection?> GetAsync(Guid id) =>
            await sessionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(SessionConnection newBook) =>
            await sessionCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(Guid id, SessionConnection updatedBook) =>
            await sessionCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(Guid id) =>
            await sessionCollection.DeleteOneAsync(x => x.Id == id);
    }
}
