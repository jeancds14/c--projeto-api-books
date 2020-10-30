using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repository.Interface
{
    public interface IBookRentRepository
    {
        Task<BookRent> Add(BookRent bookRent);
        Task<BookRent> Edit(BookRent bookRent);
        Task<BookRent> Find(int id);
        Task<IEnumerable<BookRent>> GetAllByDelivery();
        Task<IEnumerable<BookRent>> GetAll();
        Task Delete(int id);
    }
}
