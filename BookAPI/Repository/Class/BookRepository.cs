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
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext db;
        public BookRepository(ApplicationContext ctx)
        {
            db = ctx;
        }

        public async Task<Book> Add(Book book)
        {
            db.Book.Add(book);
            await db.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Find(int id)
        {
            var result = await db.Book.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var result = await db.Book.ToListAsync();
            return result;
        }

        public async Task Delete(int id)
        {
            var result = await db.Book.Where(x => x.Id == id).FirstOrDefaultAsync();
            db.Book.Remove(result);
            await db.SaveChangesAsync();
        }
    }
}
