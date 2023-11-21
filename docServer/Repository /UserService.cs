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
            try
            {
                context.Set<User>().Add(user);
                context.SaveChanges();
                _logger.LogInformation("Successfully created user at {Timestamp}", DateTime.Now);
                return true;
            } catch(Exception ex)
            {
                _logger.LogError($"Error creating user");
                _logger.LogError(ex, "Error creating user at {Timestamp}", DateTime.Now);
                return false;
            }
            
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

        public (bool, string) UpdateUSer(SignupDTO userSignUpDTO)
        {
            //selecting user based on email from db
            var user = context.Set<User>().FirstOrDefault(u => u.Email == userSignUpDTO.Email);
            try {
                if (user == null)
                {
                    return (false, "User not found for email");
                }
                else
                {
                    user.FullName = userSignUpDTO.FullName;
                    user.Email = userSignUpDTO.Email;
                    user.Password = userSignUpDTO.Password;

                    //saving changes to db
                    context.SaveChanges();

                    return (true, "User updated successfully");
                }
            }
            
            catch (Exception ex)
             {
                // Log the exception or handle it as needed
                _logger.LogError(ex, "Error updating user at {Timestamp}", DateTime.Now);
                return (false, $"Error updating user: {ex.Message}");
            }
        }

        public (bool, string) UpdateUSerPassword(SignupDTO userSignUpDTO)
        {
            //selecting user based on email from db
            var user = context.Set<User>().FirstOrDefault(u => u.Email == userSignUpDTO.Email);
            try
            {
                if (user == null)
                {
                    return (false, "User not found for email");
                }
                else
                {
         
                    user.Password = userSignUpDTO.Password;

                    //saving changes to db
                    context.SaveChanges();

                    return (true, "User password updated successfully");
                }
            }

            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                _logger.LogError(ex, "Error updating userpassword at {Timestamp}", DateTime.Now);
                return (false, $"Error updating user password: {ex.Message}");
            }
        }

    }
}

