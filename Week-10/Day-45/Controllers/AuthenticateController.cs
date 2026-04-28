using Contact_Management_Service.Repository;
using Contact_Management_Service.Services;
using Contact_Management_Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contact_Management_Service.Exceptions;

namespace Contact_Management_Service.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IUserRepository _user;

        public AuthenticateController(JwtService jwtService, IUserRepository user)              
        {
            _jwtService = jwtService;
            _user = user;
        }


        [HttpPost("register")]
        public async Task<IActionResult> UserRegister(User user)
        {
            if(!ModelState.IsValid)
            {
                throw new BadHttpRequestException("Bad Request, Coorect It");
            }

            await _user.CreateUserAsync(user);
            return Ok("User Registered successfully");

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            if(!ModelState.IsValid)
                throw new BadHttpRequestException("Bad Request, Coorect It");

            var u = await _user.GetUser(user.Email, user.Password);
            if (u == null)
                throw new NotFoundException("User details not found");

            var token = _jwtService.GenerateJSONWebToken(u);

            return Ok(new { Token = token });
        }
    }
}
