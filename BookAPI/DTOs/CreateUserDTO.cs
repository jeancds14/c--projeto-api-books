using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.DTOs
{
    public class CreateUserDTO
    {
        public string email { get; set; }
        public bool success { get; set; }

        public CreateUserDTO(string Email, bool Success)
        {
            email = Email;
            success = Success;
        }
    }
}
