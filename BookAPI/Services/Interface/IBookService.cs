using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services.Interface
{
    public interface IBookService
    {
        Task<Book> CreateBook(Book book);
        Task<IEnumerable<Book>> GetAllBook();
        Task<Book> GetBookById(int id);
        Task<bool> DeleteBook(int id);
    }
}
