using System.Threading;
using System.Threading.Tasks;
using Entities;

namespace Data.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        //Task<User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken);

        //Task AddAsync(User user, string password, CancellationToken cancellationToken);
        //Task UpdateSecuirtyStampAsync(User user, CancellationToken cancellationToken);
        //Task UpdateLastLoginDateAsync(User user, CancellationToken cancellationToken);
    }
}