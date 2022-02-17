using Twitter.MongoDB.Infra.Configurations;
using MongoDB.Driver;

namespace Twitter.MongoDB.Infra.Data
{
    public class TwitterContext : ITwitterContext
    {
        private readonly IMongoDatabase database;

        public TwitterContext(MongoDbConfiguration mongoDbConfiguration)
        {
            System.Console.WriteLine($"TwitterContext");

            var client = new MongoClient(mongoDbConfiguration.ConnectionString);

            this.database = client.GetDatabase(mongoDbConfiguration.Database);

            TwitterContextSeed.SeedData(this.database);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return this.database.GetCollection<T>(name);
        }
    }
}
