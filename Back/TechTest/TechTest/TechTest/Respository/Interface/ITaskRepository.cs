using TechTest.Dto;

namespace TechTest.Respository.Interface
{
    public interface ITaskRepository
    {
        Task createTask(Modelos.Task task);
        Task<IEnumerable<Modelos.Task?>> getAllTask();
        Task<Modelos.Task?> getTask(int idTask);
        Task updateTask(Modelos.Task task);
    }
}
