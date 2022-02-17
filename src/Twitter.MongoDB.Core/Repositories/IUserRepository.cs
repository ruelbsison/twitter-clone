using Twitter.MongoDB.Core.Entities;
using System.Threading.Tasks;

namespace Twitter.MongoDB.Core.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUserNameAsync(string userName);
    }
}
