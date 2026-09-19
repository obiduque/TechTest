using TechTest.Dto;

namespace TechTest.Business.Interface
{
    public interface ITaskBusiness
    {
        Task<Response> getTasks(TaskFilter filter);
        Task<Response> createTask(TechTest.Modelos.Task task);
        Task<Response> updateTaskState(int idTask);
    }
}
