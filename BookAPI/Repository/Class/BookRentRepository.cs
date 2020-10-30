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
    public class BookRentRepository : IBookRentRepository
    {
        private readonly ApplicationContext db;
        public BookRentRepository(ApplicationContext ctx)
        {
            db = ctx;
        }

        public async Task<BookRent> Add(BookRent bookRent)
        {
            db.BookRents.Add(bookRent);
            await db.SaveChangesAsync();
            return bookRent;
        }

        public async Task<BookRent> Find(int id)
        {
            var result = await db.BookRents.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<BookRent>> GetAll()
        {
            var result = await db.BookRents.ToListAsync();
            return result;
        }

        public async Task Delete(int id)
        {
            var result = await db.BookRents.Where(x => x.Id == id).FirstOrDefaultAsync();
            db.BookRents.Remove(result);
            await db.SaveChangesAsync();
        }
    }
}
