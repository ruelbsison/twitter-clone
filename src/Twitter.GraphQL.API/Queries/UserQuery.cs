using Twitter.MongoDB.Core.Entities;
using Twitter.MongoDB.Core.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Twitter.GraphQL.API.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class UserQuery
    {
        public Task<IEnumerable<User>> GetUsersAsync([Service] IUserRepository userRepository) =>
            userRepository.GetAllAsync();

        public Task<User> GetUserAsync(string userName, [Service] IUserRepository userRepository) =>
            userRepository.GetByUserNameAsync(userName);
    }
}
