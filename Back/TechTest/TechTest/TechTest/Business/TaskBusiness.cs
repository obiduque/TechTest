using TechTest.Modelos;
using TechTest.Dto;
using TechTest.Respository.Interface;
using TechTest.Business.Interface;

namespace TechTest.Business
{
    public class TaskBusiness: ITaskBusiness
    {
        readonly ITaskRepository _taskRepository;
        public TaskBusiness(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Response> getTasks(TaskFilter filter)
        {
            var rsp = await _taskRepository.getTaskByFilter(filter);
            return new Response(0, "Consuta exitosa", rsp);
        }
        public async Task<Response> createTask(TechTest.Modelos.Task task)
        {
            await _taskRepository.createTask(task);
            return new Response(0,"Tarea creada exitosamente", null);
        }
        public async Task<Response> updateTaskState(int idTask)
        {
            var task = await _taskRepository.getTask(idTask);
            if (task == null)
            {
                return new Response(1, "Tarea no encontrada", null);
            }
            if(task.Estado == "Pending")
            {
                task.Estado = "InProgress";
            }else if(task.Estado == "InProgress")
            {
                task.Estado = "Done";
            }
            await _taskRepository.updateTask(task);
            return new Response(0,"Estado actualizado exitosamente", null);
        }
    }
}
