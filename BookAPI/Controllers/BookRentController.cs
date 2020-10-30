using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.DTOs;
using BookAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer", Roles = "Admin")]
    public class BookRentController : ControllerBase
    {
        private readonly IBookRentService bookRentService;
        public BookRentController(IBookRentService BookRentService)
        {
            bookRentService = BookRentService;
        }

        [HttpPost]
        public async Task<object> RegisterBookRent([FromBody] FormRegisterBookRentDTO bookRent)
        {
            dynamic result = await bookRentService.RegisterBookRent(bookRent);

            if (result.success)
            {
                return result;
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public async Task<object> GetAllBooksByDelivery()
        {
            var result = await bookRentService.GetBookRent();

            if (result != null)
            {
                return result;
            }
            else
            {
                return new
                {
                    success = false
                };
            }
        }

        [HttpPut]
        public async Task<object> ReturnBookRent([FromBody] FormReturnBookRentDTO bookRent)
        {
            dynamic result = await bookRentService.ReturnBookRent(bookRent);

            if (result.success)
            {
                return result;
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
