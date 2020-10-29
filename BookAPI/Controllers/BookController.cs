using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Models;
using BookAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        public BookController (IBookService BookService)
        {
            bookService = BookService;
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<object> CreateBook([FromBody] Book book)
        {
            var result = await bookService.CreateBook(book);
            if(result != null)
            {
                return new
                {
                    success = true,
                    data = result
                };
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<object> GetAllBook()
        {
            var result = await bookService.GetAllBook();
            if(result != null)
            {
                return new
                {
                    success = true,
                    data = result
                };
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        [Authorize("Bearer")]
        public async Task<object> GetBook(int Id)
        {
            var result = await bookService.GetBookById(Id);
            if(result != null)
            {
                return new
                {
                    success = true,
                    data = result
                };
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        [Authorize("Bearer")]
        public async Task<object> DeteleBook(int Id)
        {
            var result = await bookService.DeleteBook(Id);
            if (result)
            {
                return new
                {
                    success = true
                };
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
