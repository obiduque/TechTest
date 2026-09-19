using TechTest.Modelos;
using TechTest.Dto;
using TechTest.Respository.Interface;
using TechTest.Business.Interface;

namespace TechTest.Business
{
    public class UserBusiness: IUserBusiness
    {
        readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Response> getAllUsers()
        {
            var rsp = await _userRepository.getAllUsers();
            return new Response(0, "Consuta exitosa", rsp);
        }
        public async Task<Response> createUser(User user)
        {
            await _userRepository.createAsync(user);
            return new Response(0,"Usuario creado exitosamente", null);
        }
    }
}
