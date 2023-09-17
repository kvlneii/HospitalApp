using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalApp.Models;
using HospitalApp.Models.DTO;
using HospitalApp.Services;

namespace HospitalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountDbService _accountDbService;

        public AccountsController(IAccountDbService accountDbService)
        {
            _accountDbService = accountDbService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            var result = await _accountDbService.LoginAsync(userDTO);

            switch (result.StatusResponse)
            {
                case StatusResponse.OK:
                    return Ok(result);
                case StatusResponse.BadPassword:
                    return Unauthorized("Password is wrong");
                case StatusResponse.UserNotFound:
                    return Unauthorized("Login is not found");
                default:
                    return Unauthorized();
            }
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken(string refreshToken)
        {
            var result = await _accountDbService.RefreshTokenAsync(refreshToken);

            switch (result.StatusResponse)
            {
                case StatusResponse.OK:
                    return Ok(result);
                case StatusResponse.RefreshTokenIsExpired:
                    return Unauthorized("Refresh Token is expired");
                case StatusResponse.UserNotFound:
                    return Unauthorized("Login is not found");
                default:
                    return Unauthorized();
            }
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(UserDTO userDTO)
        {
            var result = await _accountDbService.SignUpAsync(userDTO);

            switch (result.StatusResponse)
            {
                case StatusResponse.OK:
                    return Ok(result);
                case StatusResponse.UserIsAlreadyRegistered:
                    return Unauthorized("User with this login is already registered");
                default:
                    return Unauthorized();
            }
        }
    }
}
