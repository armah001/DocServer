using System;
using docServer.DTOs;
using docServer.Models;

namespace docServer.IRepository
{
	public interface IUserService
	{
        bool CreateUser(User user);
        (bool, string) AuthenticateUser(LoginDTO userLogInDto);
        (bool, string) UpdateUSer(SignupDTO userSignupDTO);
        (bool, string) UpdateUSerPassword(SignupDTO userSignupDTO);


    }
}

