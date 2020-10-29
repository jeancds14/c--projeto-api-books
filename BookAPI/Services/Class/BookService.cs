using BookAPI.Models;
using BookAPI.Repository.Interface;
using BookAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services.Class
{
    public class BookService : IBookService
    {

        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository BookRepository)
        {
            bookRepository = BookRepository;
        }

        public async Task<Book> CreateBook(Book book)
        {
            try
            {
                var result = await bookRepository.Add(book);
                return book;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            try
            {
                var result = await bookRepository.GetAll();
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        } 

        public async Task<Book> GetBookById(int id)
        {
            try
            {
                var result = await bookRepository.Find(id);
                return result;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteBook(int id)
        {
            try
            {
                await bookRepository.Delete(id);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
