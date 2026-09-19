using Microsoft.EntityFrameworkCore;
using TechTest.Modelos;
using TechTest.Respository.Interface;
using Task = System.Threading.Tasks.Task;

namespace TechTest.Respository
{
    public class UserRepository(MiDbContext context): IUserRepository
    {
        public async Task<IEnumerable<User?>> getAllUsers()
        {
            return await context.Users.ToListAsync();
        }
        public async Task createAsync(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
