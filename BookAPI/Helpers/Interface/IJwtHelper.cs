using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Helpers.Interface
{
    public interface IJwtHelper
    {
        string GenerateJWT(string name, string role);
    }
}
