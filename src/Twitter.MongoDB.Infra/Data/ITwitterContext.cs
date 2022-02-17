using MongoDB.Driver;

namespace Twitter.MongoDB.Infra.Data
{
    public interface ITwitterContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
