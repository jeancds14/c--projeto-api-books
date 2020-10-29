using BookAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services.Interface
{
    public interface IUserService
    {
        Task<CreateUserDTO> CreateUser(FormRegisterUserDTO userDTO);
        Task<object> AuthenticationUser(FormLoginDTO userDTO);
    }
}
