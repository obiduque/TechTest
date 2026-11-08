using Moq;
using TechTest.Business.Interface;
using TechTest.Controllers;
using TechTest.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestTechTest.Controller
{
    public class UserControllerTest
    {
        private Mock<IUserBusiness> _userBusinessMock;
        private UsersController _controller;

        public UserControllerTest()
        {
            _userBusinessMock = new Mock<IUserBusiness>();
            _controller = new UsersController(_userBusinessMock.Object);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnOkWithResponse()
        {
            var mockResponse = new Response(
                0, "Consulta exitosa", new List<TechTest.Modelos.User> { new TechTest.Modelos.User() }
            );
            _userBusinessMock
                .Setup(b => b.getAllUsers())
                .ReturnsAsync(mockResponse);

            var result = await _controller.GetUsers();

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnedResponse = okResult.Value.Should().BeOfType<Response>().Subject;

            returnedResponse.Should().BeEquivalentTo(mockResponse);

            _userBusinessMock.Verify(b => b.getAllUsers(), Times.Once);
        }

        [Fact]
        public async Task PostTasks_ShouldReturnOkWithResponse()
        {
            // Arrange
            var newUser = new TechTest.Modelos.User();

            var mockResponse = new Response(0,"Usuario creado", null);

            _userBusinessMock
                .Setup(b => b.createUser(newUser))
                .ReturnsAsync(mockResponse);

            var result = await _controller.PostUsers(newUser);

            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnedResponse = okResult.Value.Should().BeOfType<Response>().Subject;

            returnedResponse.Should().BeEquivalentTo(mockResponse);

            _userBusinessMock.Verify(b => b.createUser(newUser), Times.Once);
        }
    }
}
