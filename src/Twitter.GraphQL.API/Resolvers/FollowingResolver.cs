using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Resolvers
{
    [ExtendObjectType(Name = "Following")]
    public class FollowingResolver
    {
        public Task<IEnumerable<Following>> GetFollowingsAsync(
            [Parent] User user,
            [Service] IFollowingRepository followingRepository) => followingRepository.GetByUserIdAsync(user.Id);
    }
}
