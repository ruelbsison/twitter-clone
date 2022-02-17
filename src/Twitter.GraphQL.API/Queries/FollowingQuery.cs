using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class FollowingQuery
    {
        public Task<Following> GetFollowingAsync(string id, [Service] IFollowingRepository followingRepository) =>
            followingRepository.GetByIdAsync(id);

        public Task<IEnumerable<Following>> GetFollowingsByUserIdAsync(string userId, [Service] IFollowingRepository followingRepository) =>
            followingRepository.GetByUserIdAsync(userId);
    }
}
