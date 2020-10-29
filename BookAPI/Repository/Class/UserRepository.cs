using BookAPI.Context;
using BookAPI.Models;
using BookAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repository.Class
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext db;
        public UserRepository(ApplicationContext ctx)
        {
            db = ctx;
        }

        public async Task<User> Add(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User> Find(int id)
        {
            var result = await db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<User> FindByEmail(string email)
        {
            var result = await db.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await db.Users.ToListAsync();
            return result;
        }

        public async Task Delete(int id)
        {
            var result = await db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            db.Users.Remove(result);
            await db.SaveChangesAsync();
        }
    }
}
