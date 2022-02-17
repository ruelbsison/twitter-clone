using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class FollowingMutation
    {
        public async Task<Following> CreateFollowingAsync(Following Following, [Service] IFollowingRepository followingRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await followingRepository.InsertAsync(Following);

            await eventSender.SendAsync(nameof(Subscriptions.FollowingSubscriptions.OnCreateAsync), result);

            return result;
        }

        public async Task<bool> RemoveFollowingAsync(string id, [Service] IFollowingRepository followingRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await followingRepository.RemoveAsync(id);

            if (result)
            {
                await eventSender.SendAsync(nameof(Subscriptions.FollowingSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }
    }
}
