using System;
using System.Runtime.InteropServices;
using docServer.Data;
using docServer.DTOs;
using docServer.IRepository;
using docServer.Models;
using Microsoft.EntityFrameworkCore;

namespace docServer.Repository
{
	public class UserService:IUserService
	{
        private readonly docServerContext context;
        private readonly ILogger _logger;
        public UserService(docServerContext context,  ILogger<UserService> logger)
        {
            this.context = context;
            _logger = logger;
        }

        public bool CreateUser(User user)
        {
            context.Set<User>().Add(user);
            context.SaveChanges();
            _logger.LogInformation("Successfully created user at {Timestamp}", DateTime.Now);
            return true;
        }

        public (bool, string) AuthenticateUser(LoginDTO userLogInDto)
        {
            var user = context.Set<User>().FirstOrDefault(u => u.Email == userLogInDto.Email);

            if (user == null)
            {
                return (false, "User not found for email");
            }
            else
            {
                if (user.Password == userLogInDto.Password)
                {
                    return (true, "Authentication successful");
                }
                else
                {
                    return (false, "Wrong password");
                }
            }
        }

    }
}

