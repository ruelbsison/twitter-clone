using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using Twitter.MongoDB.Infra.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Twitter.MongoDB.Infra.Repositories
{
    public class FollowingRepository : BaseRepository<Following>, IFollowingRepository
    {
        public FollowingRepository(ITwitterContext catalogContext) : base(catalogContext)
        {
        }

        public async Task<IEnumerable<Following>> GetByUserIdAsync(string userId)
        {
            var filter = Builders<Following>.Filter.Eq("UserId", userId);

            return await collection.Find(filter).ToListAsync();
        }
    }
}
