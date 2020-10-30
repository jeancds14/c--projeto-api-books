using BookAPI.DTOs;
using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services.Interface
{
    public interface IBookRentService
    {
        Task<object> RegisterBookRent(FormRegisterBookRentDTO bookRentDTO);
        Task<object> ReturnBookRent(FormReturnBookRentDTO bookRentDTO);
        Task<IEnumerable<BookRent>> GetBookRent();
    }
}
