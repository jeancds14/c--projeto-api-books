using BookAPI.DTOs;
using BookAPI.Models;
using BookAPI.Repository.Interface;
using BookAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services.Class
{
    public class BookRentService : IBookRentService
    {
        private readonly IBookRentRepository bookRentRepository;
        private readonly IUserRepository userRepository;
        private readonly IBookRepository bookRepository;
        public BookRentService(
            IBookRentRepository BookRentRepository,
            IBookRepository BookRepository,
            IUserRepository UserRepository
        )
        {
            bookRentRepository = BookRentRepository;
            bookRepository = BookRepository;
            userRepository = UserRepository;
        }

        public async Task<object> RegisterBookRent(FormRegisterBookRentDTO bookRentDTO)
        {
            try
            {
                BookRent bookRent = new BookRent();

                bookRent.Book = await bookRepository.Find(bookRentDTO.idBook);
                bookRent.User = await userRepository.Find(bookRentDTO.idUser);
                bookRent.LoanDate = DateTime.Now;
                bookRent.ExpectedDate = DateTime.Now.AddDays(7);

                var result = await bookRentRepository.Add(bookRent);

                if (result != null)
                {
                    return new
                    {
                        success = true
                    };
                }
                else
                {
                    return new
                    {
                        success = false
                    };
                }

            } catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new
                {
                    success = false
                };
            }
        }

        public async Task<object> ReturnBookRent(FormReturnBookRentDTO bookRentDTO)
        {
            try
            {
                var bookRent = await bookRentRepository.Find(bookRentDTO.idBookRent);
                bookRent.DeliveryDate = bookRentDTO.DeliveryDate;

                var result = await bookRentRepository.Edit(bookRent);

                if (result != null)
                {
                    return new
                    {
                        success = true
                    };
                }
                else
                {
                    return new
                    {
                        success = false
                    };
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new
                {
                    success = false
                };
            }
        }
    
        public async Task<IEnumerable<BookRent>> GetBookRent()
        {
            try
            {
                var result = await bookRentRepository.GetAllByDelivery();
                return result;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
