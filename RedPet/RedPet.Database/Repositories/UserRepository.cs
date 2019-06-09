using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedPet.Database.Entities.Identity;

namespace RedPet.Database.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(RedPetContext context) : base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await DbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
