using Twitter.MongoDB.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Twitter.MongoDB.Core.Repositories
{
    public interface ITweetRepository : IBaseRepository<Tweet>
    {
        Task<IEnumerable<Tweet>> GetByUserNameAsync(string userName);
    }
}
