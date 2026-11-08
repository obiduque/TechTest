using FluentAssertions;
using Moq;
using TechTest.Business;
using TechTest.Respository.Interface;

namespace UnitTestTechTest.Business
{
    public class TaskBusinessTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly TaskBusiness _taskBusiness;

        public TaskBusinessTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _taskBusiness = new TaskBusiness(_taskRepositoryMock.Object);
        }

        [Fact]
        public async Task GetTasks()
        {
            var mockTaskList = new List<TechTest.Modelos.Task>{
                new TechTest.Modelos.Task { Id = 0, Titulo = "Tarea 1", Estado = "Pending" }
            };

            _taskRepositoryMock
                .Setup(r => r.getAllTask())
                .ReturnsAsync(mockTaskList);

            var result = await _taskBusiness.getTasks();

            result.Should().NotBeNull();
            result.Status.Should().Be(0);
            result.Message.Should().Be("Consuta exitosa");
            result.Data.Should().BeEquivalentTo(mockTaskList);

            _taskRepositoryMock.Verify(r => r.getAllTask(), Times.Once);
        }

        [Fact]
        public async Task CreateTask()
        {
            var newTask = new TechTest.Modelos.Task
            {
                Id = 1,
                Titulo = "Nueva Tarea",
                Estado = "Pending"
            };

            _taskRepositoryMock
                .Setup(r => r.createTask(newTask))
                .Returns(Task.FromResult(true));

            var result = await _taskBusiness.createTask(newTask);

            result.Should().NotBeNull();
            result.Status.Should().Be(0);
            result.Message.Should().Be("Tarea creada exitosamente");
            result.Data.Should().BeNull();

            _taskRepositoryMock.Verify(r => r.createTask(newTask), Times.Once);
        }

        [Fact]
        public async Task CreateTask_Error()
        {
            var newTask = new TechTest.Modelos.Task
            {
                Id = 1,
                Titulo = "Nueva Tarea",
                Estado = "Pending"
            };

            _taskRepositoryMock
                .Setup(r => r.createTask(newTask))
                .Returns(Task.FromResult(false));

            var result = await _taskBusiness.createTask(newTask);

            result.Should().NotBeNull();
            result.Status.Should().Be(1);
            result.Message.Should().Be("Error al crear la tarea");
            result.Data.Should().BeNull();

            _taskRepositoryMock.Verify(r => r.createTask(newTask), Times.Once);
        }

        [Fact]
        public async Task UpdateTaskState_ShouldReturnNotFound()
        {
            int idTask = 99;

            _taskRepositoryMock
                .Setup(r => r.getTask(idTask))
                .ReturnsAsync((TechTest.Modelos.Task)null);

            var result = await _taskBusiness.updateTaskState(idTask);

            result.Should().NotBeNull();
            result.Status.Should().Be(1);
            result.Message.Should().Be("Tarea no encontrada");
            result.Data.Should().BeNull();

            _taskRepositoryMock.Verify(r => r.updateTask(It.IsAny<TechTest.Modelos.Task>()), Times.Never);
        }

        [Fact]
        public async Task UpdateTaskState_ShouldChangeStateToInProgress()
        {
            int idTask = 1;
            var existingTask = new TechTest.Modelos.Task
            {
                Id = idTask,
                Estado = "Pending"
            };

            _taskRepositoryMock
                .Setup(r => r.getTask(idTask))
                .ReturnsAsync(existingTask);

            _taskRepositoryMock
                .Setup(r => r.updateTask(It.IsAny<TechTest.Modelos.Task>()))
                .Returns(Task.CompletedTask);

            var result = await _taskBusiness.updateTaskState(idTask);

            result.Should().NotBeNull();
            result.Status.Should().Be(0);
            result.Message.Should().Be("Estado actualizado exitosamente");

            existingTask.Estado.Should().Be("InProgress");

            _taskRepositoryMock.Verify(r => r.updateTask(existingTask), Times.Once);
        }

        [Fact]
        public async Task UpdateTaskState_ShouldChangeStateToDone()
        {
            int idTask = 1;
            var existingTask = new TechTest.Modelos.Task
            {
                Id = idTask,
                Estado = "InProgress"
            };

            _taskRepositoryMock
                .Setup(r => r.getTask(idTask))
                .ReturnsAsync(existingTask);

            _taskRepositoryMock
                .Setup(r => r.updateTask(It.IsAny<TechTest.Modelos.Task>()))
                .Returns(Task.CompletedTask);

            var result = await _taskBusiness.updateTaskState(idTask);

            result.Should().NotBeNull();
            result.Status.Should().Be(0);
            result.Message.Should().Be("Estado actualizado exitosamente");

            existingTask.Estado.Should().Be("Done");

            _taskRepositoryMock.Verify(r => r.updateTask(existingTask), Times.Once);
        }
    }
}
