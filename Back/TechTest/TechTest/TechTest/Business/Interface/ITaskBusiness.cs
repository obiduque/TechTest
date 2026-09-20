using TechTest.Dto;

namespace TechTest.Business.Interface
{
    public interface ITaskBusiness
    {
        Task<Response> getTasks();
        Task<Response> createTask(TechTest.Modelos.Task task);
        Task<Response> updateTaskState(int idTask);
    }
}
