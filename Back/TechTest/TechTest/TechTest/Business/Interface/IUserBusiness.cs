using TechTest.Dto;
using TechTest.Modelos;

namespace TechTest.Business.Interface
{
    public interface IUserBusiness
    {
        Task<Response> getAllUsers();
        Task<Response> createUser(User user);
    }
}
