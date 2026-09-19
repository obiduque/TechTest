using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechTest.Business.Interface;
using TechTest.Dto;
using TechTest.Modelos;

namespace TechTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        readonly IUserBusiness _userBusiness;
        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<Response>> GetUsers()
        {
            return Ok(await _userBusiness.getAllUsers());
        }
        [HttpPost]
        public async Task<ActionResult<Response>> PostUsers([FromBody] User user)
        {
            return Ok(await _userBusiness.createUser(user));
        }
    }
}
