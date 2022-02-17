using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class UserMutation
    {
        public async Task<User> CreateUserAsync(User user, [Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await userRepository.InsertAsync(user);

            await eventSender.SendAsync(nameof(Subscriptions.UserSubscriptions.OnCreateAsync), result);

            return result;
        }

        public async Task<bool> RemoveUserAsync(string id, [Service] IUserRepository userRepository, [Service] ITopicEventSender eventSender)
        {
            var result = await userRepository.RemoveAsync(id);

            if (result)
            {
                await eventSender.SendAsync(nameof(Subscriptions.UserSubscriptions.OnRemoveAsync), id);
            }

            return result;
        }
    }
}
