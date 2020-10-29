using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<User> Find(int id);
        Task<IEnumerable<User>> GetAll();
        Task Delete(int id);
        Task<User> FindByEmail(string email);
    }
}
