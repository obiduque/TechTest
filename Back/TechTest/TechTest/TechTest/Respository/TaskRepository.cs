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
        public async Task<IEnumerable<Modelos.Task?>> getTaskByFilter(TaskFilter filter)
        {
            var paramsList = new[]
            {
                new MySqlParameter("@p_usuario_id", filter.IdUser),
                new MySqlParameter("@p_estado", filter.State ?? (object)DBNull.Value),
                new MySqlParameter("@p_ordenado", filter.Order),
                new MySqlParameter("@p_meta_key", filter.MetaKey ?? (object)DBNull.Value),
                new MySqlParameter("@p_meta_value", filter.metaData ?? (object)DBNull.Value)
            };
            try
            {
                return await context.Tasks
                .FromSqlRaw("CALL sp_consultar_tareas(@p_usuario_id, @p_estado, @p_ordenado, @p_meta_key, @p_meta_value)", paramsList)
                .ToListAsync();
            }
            catch (Exception ex) {
                return null;
            }

        }
    }
}
