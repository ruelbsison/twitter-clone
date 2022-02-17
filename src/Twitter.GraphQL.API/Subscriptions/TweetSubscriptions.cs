using Twitter.MongoDB.Core.Entities;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Subscriptions
{
    [ExtendObjectType(Name = "Subscription")]
    public class TweetSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<Tweet> OnCreateAsync([EventMessage] Tweet tweet) =>
            Task.FromResult(tweet);

        [Subscribe]
        [Topic]
        public Task<string> OnRemoveAsync([EventMessage] string tweetId) =>
            Task.FromResult(tweetId);
    }
}
