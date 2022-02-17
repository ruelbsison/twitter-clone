using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class TweetQuery
    {
        public Task<IEnumerable<Tweet>> GetTweetsAsync([Service] ITweetRepository tweetRepository) =>
            tweetRepository.GetAllAsync();

        public Task<Tweet> GetTweetAsync(string id, [Service] ITweetRepository tweetRepository) =>
            tweetRepository.GetByIdAsync(id);

        public Task<IEnumerable<Tweet>> GetTweetsByUserNameAsync(string userName, [Service] ITweetRepository tweetRepository) =>
            tweetRepository.GetByUserNameAsync(userName);
    }
}
