using Moq;
using System.Timers;
using TechTest.Business.Interface;
using TechTest.Controllers;
using TechTest.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestTechTest.Controller
{
    public class TaskControllerTest
    {
        private Mock<ITaskBusiness> _taskBusinessMock;
        private TasksController _controller;

        public TaskControllerTest()
        {
            _taskBusinessMock = new Mock<ITaskBusiness>();
            _controller = new TasksController(_taskBusinessMock.Object);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnOkWithResponse()
        {
            var mockResponse = new Response(
                0, "Consulta exitosa", new List<TechTest.Modelos.Task> { new TechTest.Modelos.Task() }
            );
            _taskBusinessMock
                .Setup(b => b.getTasks())
                .ReturnsAsync(mockResponse);

            var result = await _controller.GetTasks();

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnedResponse = okResult.Value.Should().BeOfType<Response>().Subject;

            returnedResponse.Should().BeEquivalentTo(mockResponse);

            _taskBusinessMock.Verify(b => b.getTasks(), Times.Once);
        }

        [Fact]
        public async Task PostTasks_ShouldReturnOkWithResponse()
        {
            // Arrange
            var newTask = new TechTest.Modelos.Task();

            var mockResponse = new Response(0,"Tarea creada", null);

            _taskBusinessMock
                .Setup(b => b.createTask(newTask))
                .ReturnsAsync(mockResponse);

            var result = await _controller.PostTasks(newTask);

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnedResponse = okResult.Value.Should().BeOfType<Response>().Subject;

            returnedResponse.Should().BeEquivalentTo(mockResponse);

            _taskBusinessMock.Verify(b => b.createTask(newTask), Times.Once);
        }

        [Fact]
        public async Task PutTasks_ShouldReturnOkWithResponse()
        {
            int idTask = 5;
            var mockResponse = new Response(0,"Estado actualizado",null);

            _taskBusinessMock
                .Setup(b => b.updateTaskState(idTask))
                .ReturnsAsync(mockResponse);

            var result = await _controller.PutTasks(idTask);

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnedResponse = okResult.Value.Should().BeOfType<Response>().Subject;

            returnedResponse.Should().BeEquivalentTo(mockResponse);

            _taskBusinessMock.Verify(b => b.updateTaskState(idTask), Times.Once);
        }
    }
}
