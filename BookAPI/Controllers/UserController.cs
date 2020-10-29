using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.DTOs;
using BookAPI.Models;
using BookAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpPost]
        //[Authorize("admin")]
        [AllowAnonymous]
        public async Task<object> CreateUser([FromBody] FormRegisterUserDTO user)
        {
            if(ModelState.IsValid)
            {
                var result = await userService.CreateUser(user);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<object> Login([FromBody] FormLoginDTO user)
        {
            try
            {
                dynamic result = await userService.AuthenticationUser(user);

                if (result.success)
                {
                    return result;
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Oops, esse e-mail não existe em nossa base de dados."
                });
            }
            
        }
    }
}
