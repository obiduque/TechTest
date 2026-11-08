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
        public async Task<bool> createAsync(User user)
        {
            try
            {
                await context.AddAsync(user);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("No se pudo crear el usuario");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado al crear la tarea. " + ex.Message);
                return false;
            }
        }
    }
}
