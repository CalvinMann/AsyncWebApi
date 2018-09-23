using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [Route("api/syncbooks")]
    [ApiController]

    public class SyncBooksController : ControllerBase
    {
        private IBooksRepository _booksRepository;

        public SyncBooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
        }

        [HttpGet]
        public  IActionResult GetBooks()
        {
            var bookEntities =  _booksRepository.GetBooks();

            return Ok(bookEntities);
        }
    }
}