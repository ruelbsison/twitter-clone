using Twitter.MongoDB.Core.Entities;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Subscriptions
{
    [ExtendObjectType(Name = "Subscription")]
    public class FollowingSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<Following> OnCreateAsync([EventMessage] Following following) =>
            Task.FromResult(following);

        [Subscribe]
        [Topic]
        public Task<string> OnRemoveAsync([EventMessage] string followingId) =>
            Task.FromResult(followingId);
    }
}
