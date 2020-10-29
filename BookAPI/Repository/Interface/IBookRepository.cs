using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repository.Interface
{
    public interface IBookRepository
    {
        Task<Book> Add(Book book);
        Task<Book> Find(int id);
        Task<IEnumerable<Book>> GetAll();
        Task Delete(int id);
    }
}
