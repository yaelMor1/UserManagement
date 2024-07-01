using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Repositories;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            user.UserId = Guid.NewGuid();
            _userRepository.CreateUser(user);
            return Ok(user);
        }
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(Guid userId)
        {
            _userRepository.DeleteUser(userId);
            return NoContent();
        }
        [HttpPost("validate")]
        public IActionResult ValidateUser([FromBody] User user)
        {
            var isValid = _userRepository.validateUser(user.UserName, user.UserPassword);
            return Ok(isValid);
        }
       
    }
}
