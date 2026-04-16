using AuthService.Models;
using AuthService.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        
        private readonly JwtService _jwtService;
        private readonly IAuthenticateService _service;


        public AuthenticateController(JwtService jwtService, IAuthenticateService service)
        {

            _jwtService = jwtService;

            _service = service;
           
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(User requestUser)
        {
            var usersList = await _service.GetAllUserAsync();
            // 1. Verify the user credentials
            User? userObj = usersList.FirstOrDefault(user => user.Email ==
            requestUser.Email && user.Password == requestUser.Password);

            if (userObj != null)
            {
                // 2. Generate JWT Token
                string tokenStr = _jwtService.GenerateJSONWebToken(userObj);
                return Ok(new { token = tokenStr });
            }
            else
            {
                return BadRequest("Invalid user id or password");
            }
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _service.AddUserAsync(user);   
            return Ok(res);


        }
    }
}