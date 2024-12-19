using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;



        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var allUsers = await _userService.GetAllUsers();
                return Ok(allUsers);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}

