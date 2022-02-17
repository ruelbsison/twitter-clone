using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Resolvers
{
    [ExtendObjectType(Name = "Tweet")]
    public class TweetResolver
    {
        public Task<IEnumerable<Tweet>> GetTweetsAsync(
            [Parent] User user,
            [Service] ITweetRepository tweetRepository) => tweetRepository.GetByUserNameAsync(user.UserName);
    }
}
