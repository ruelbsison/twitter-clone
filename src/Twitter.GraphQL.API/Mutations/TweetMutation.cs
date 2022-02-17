using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class TweetMutation
    {
        public async Task<Tweet> CreateTweetAsync(Tweet tweet, [Service] ITweetRepository tweetRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await tweetRepository.InsertAsync(tweet);

            await eventSender.SendAsync(nameof(Subscriptions.TweetSubscriptions.OnCreateAsync), result);

            return result;
        }

        public async Task<bool> RemoveTweetAsync(string id, [Service] ITweetRepository tweetRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await tweetRepository.RemoveAsync(id);

            if (result)
            {
                await eventSender.SendAsync(nameof(Subscriptions.TweetSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }
    }
}
