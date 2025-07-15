using Microsoft.EntityFrameworkCore;
using RepositoryDP.Data;
using RepositoryDP.Model;

namespace RepositoryDP.Repository.UserRepo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EFContext context) : base(context)
        {


        }
        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbSet.Include("addresses").ToListAsync();
        }
    }
}
