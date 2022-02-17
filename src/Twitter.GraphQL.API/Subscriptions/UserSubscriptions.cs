using Twitter.MongoDB.Core.Entities;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Subscriptions
{
    [ExtendObjectType(Name = "Subscription")]
    public class UserSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<User> OnCreateAsync([EventMessage] User user) =>
            Task.FromResult(user);

        [Subscribe]
        [Topic]
        public Task<string> OnRemoveAsync([EventMessage] string userId) =>
            Task.FromResult(userId);
    }
}
