using Twitter.MongoDB.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Twitter.MongoDB.Core.Repositories
{
    public interface IFollowingRepository : IBaseRepository<Following>
    {
        Task<IEnumerable<Following>> GetByUserIdAsync(string userId);
    }
}
