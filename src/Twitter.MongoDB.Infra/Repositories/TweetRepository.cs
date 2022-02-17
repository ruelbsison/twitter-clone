using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using Twitter.MongoDB.Infra.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Twitter.MongoDB.Infra.Repositories
{
    public class TweetRepository : BaseRepository<Tweet>, ITweetRepository
    {
        public TweetRepository(ITwitterContext catalogContext) : base(catalogContext)
        {
        }

        public async Task<IEnumerable<Tweet>> GetByUserNameAsync(string userName)
        {
            var filter = Builders<Tweet>.Filter.Eq("UserName", userName);

            return await collection.Find(filter)
                .ToListAsync();
        }
    }
}
