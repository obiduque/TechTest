using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using TechTest.Dto;
using TechTest.Modelos;
using TechTest.Respository.Interface;
using Task = System.Threading.Tasks.Task;

namespace TechTest.Respository
{
    public class TaskRepository(MiDbContext context) : ITaskRepository
    {
        public async Task createTask(Modelos.Task task)
        {
            await context.AddAsync(task);
            await context.SaveChangesAsync();
        }
        public async Task updateTask(Modelos.Task task)
        {
            context.Update(task);
            await context.SaveChangesAsync();
        }
        public async Task<Modelos.Task?> getTask(int idTask)
        {
            return await context.Tasks.FindAsync(idTask);
        }
        public async Task<IEnumerable<Modelos.Task?>> getAllTask()
        {
            return await context.Tasks.ToListAsync();
        }
    }
}
