using BookAPI.DTOs;
using BookAPI.Helpers.Interface;
using BookAPI.Models;
using BookAPI.Repository.Interface;
using BookAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services.Class
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHelper passwordHelper;
        private readonly IJwtHelper jwtHelper;

        public UserService(
            IUserRepository UserRepository, 
            IPasswordHelper PasswordHelper,
            IJwtHelper JwtHelper
        )
        {
            userRepository = UserRepository;
            passwordHelper = PasswordHelper;
            jwtHelper = JwtHelper;
        }

        public async Task<CreateUserDTO> CreateUser(FormRegisterUserDTO userDTO)
        {
            try
            {
                User user = new User();
                user.Email = userDTO.email;
                user.Password = passwordHelper.HashPassword(userDTO.password);
                user.Role = "user";

                var result = await userRepository.Add(user);

                if(result != null)
                {
                    return new CreateUserDTO(result.Email, true);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                var a = ex;
                return null;
            }
        }

        public async Task<object> AuthenticationUser(FormLoginDTO userDTO)
        {
            try
            {
                var result = await userRepository.FindByEmail(userDTO.email);

                if (result != null)
                {
                    if(passwordHelper.VerifyPasswordHash(result.Id, userDTO.password, result.Password))
                    {
                        return new LoginDTO(jwtHelper.GenerateJWT(result.Name == "" || result.Name == null ? result.Email : result.Name, result.Role), true);
                    }
                    else
                    {
                        return new
                        {
                            success = false,
                            message = "Oops, e-mail ou senha incorreto."
                        };
                    }
                }
                else
                {
                    return new
                    {
                        success = false,
                        message = "Oops, e-mail ou senha incorreto."
                    };
                }
            }catch(Exception ex)
            {
                return new
                {
                    success = false,
                    message = "Oops, ocorreu um erro no servidor, tente novamente mais tarde."
                };
            }
        }
    }
}
