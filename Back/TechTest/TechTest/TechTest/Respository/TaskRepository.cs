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
        public async Task<bool> createTask(TechTest.Modelos.Task task)
        {
            try
            {
                await context.AddAsync(task);
                await context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("No se pudo crear la tarea por una restricción en BD para el ID: {Id}", task.Id);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inesperado al crear la tarea. "+ex.Message);
                return false;
            }
        }

        public async Task updateTask(TechTest.Modelos.Task task)
        {
            try
            {
                context.Update(task);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Conflicto de concurrencia al actualizar la tarea ID: {Id}", task.Id);
                return;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error de actualización en BD para la tarea ID: {Id} "+ex.Message, task.Id);
                return;
            }
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
