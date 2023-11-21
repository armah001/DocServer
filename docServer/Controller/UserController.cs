using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using docServer.Data;
using docServer.DTOs;
using docServer.IRepository;
using docServer.Models;
using docServer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;

namespace docServer.Controller
{
    [Route("api/v1/user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private IConfiguration _config;
        public readonly docServerContext _context;
        private readonly IUserService userService;

        public UserController(
            ILogger<UserController> logger, IMapper mapper, IConfiguration config, docServerContext context, IUserService userService)
        {
            _logger = logger;
            _mapper = mapper;
            _config = config;
            _context = context;
            this.userService = userService;
        }

        [HttpPost]
        [Route("SignUp")]
        public bool SignUp([FromForm] User user)
        {
            return userService.CreateUser(user);
        }

        [HttpPost]
        [Route("SignIn")]
        public ActionResult<string> SignIn([FromForm] LoginDTO userLogInDto)
        {
            var authenticationResult = userService.AuthenticateUser(userLogInDto);

            if (authenticationResult.Item1)
            {
                return Ok();
            }
            else
            {
                return Unauthorized(new { message = "Authentication failed", error = authenticationResult.Item2 });
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult<string> UpdateAccount([FromBody] SignupDTO userSignupDTO)
        {
            var updateResult = userService.UpdateUSer(userSignupDTO);

            if (updateResult.Item1)
            {
                return Ok();
            }
            else
            {
                return Unauthorized(new { message = "Updating User Failed", error = updateResult.Item2 });
            }
        }

        [HttpPut]
        [Route("UpdateUserPassword")]
        public ActionResult<string> ResetUserPassword([FromBody] SignupDTO userSignupDTO)
        {
            var updateResult = userService.UpdateUSerPassword(userSignupDTO);

            if (updateResult.Item1)
            {
                return Ok();
            }
            else
            {
                return Unauthorized(new { message = "Updating User Password Failed", error = updateResult.Item2 });
            }
        }

    }
}

