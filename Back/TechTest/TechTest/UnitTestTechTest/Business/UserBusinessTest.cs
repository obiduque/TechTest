using FluentAssertions;
using Moq;
using TechTest.Business;
using TechTest.Respository.Interface;

namespace UnitTestTechTest.Business
{
    public class UserBusinessTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserBusiness _userBusiness;

        public UserBusinessTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userBusiness = new UserBusiness(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllUsers()
        {
            var mockUserList = new List<TechTest.Modelos.User>{
                new TechTest.Modelos.User { Id = 1, Nombre = "Juan Pérez" },
                new TechTest.Modelos.User { Id = 2, Nombre = "María Gómez" }
            };

            _userRepositoryMock
                .Setup(r => r.getAllUsers())
                .ReturnsAsync(mockUserList);

            var result = await _userBusiness.getAllUsers();

            result.Should().NotBeNull();
            result.Status.Should().Be(0);
            result.Message.Should().Be("Consuta exitosa");
            result.Data.Should().BeEquivalentTo(mockUserList);

            _userRepositoryMock.Verify(r => r.getAllUsers(), Times.Once);
        }

        [Fact]
        public async Task CreateUser()
        {
            var newUser = new TechTest.Modelos.User{ Id = 1,Nombre = "Carlos Ruiz" };

            _userRepositoryMock
                .Setup(r => r.createAsync(newUser))
                .Returns(Task.FromResult(true));

            var result = await _userBusiness.createUser(newUser);

            result.Should().NotBeNull();
            result.Status.Should().Be(0);
            result.Message.Should().Be("Usuario creado exitosamente");
            result.Data.Should().BeNull();

            _userRepositoryMock.Verify(r => r.createAsync(newUser), Times.Once);
        }

        [Fact]
        public async Task CreateUser_Error()
        {
            var newUser = new TechTest.Modelos.User { Id = 1, Nombre = "Carlos Ruiz" };

            _userRepositoryMock
                .Setup(r => r.createAsync(newUser))
                .Returns(Task.FromResult(false));

            var result = await _userBusiness.createUser(newUser);

            result.Should().NotBeNull();
            result.Status.Should().Be(1);
            result.Message.Should().Be("Error al crear el usuario");
            result.Data.Should().BeNull();

            _userRepositoryMock.Verify(r => r.createAsync(newUser), Times.Once);
        }
    }
}
