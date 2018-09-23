using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Books.Api.Filters;
using Books.Api.Mappings;
using Books.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [Route("api/books")]
    [ApiController] //We use this attribute to ensure that we are using api routing

    public class BooksController : ControllerBase
    {
        private IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksController(IBooksRepository booksRepository, IMapper mapper)
        {
            
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [BooksResultFilter]
        public async Task<IActionResult> GetBooks()
        {
            var bookEntities = await _booksRepository.GetBooksAsync();

            return Ok(bookEntities);
        }

        [HttpGet]
        [BookResultFilter]
        [Route("{id}", Name = "GetBook")] //We give this route a name so we can call it after a post
        public async Task<IActionResult> GetBook(Guid id)
        {
            var bookEntity = await _booksRepository.GetBookAsync(id);

            if (bookEntity == null)
            {
                return NotFound();
            }

            return Ok(bookEntity);
        }


        //The [FromBody] attribute tells the framework to deserialize the body 
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookForCreation bookForCreation)
        {
            var bookEntity = _mapper.Map<Entities.Book>(bookForCreation);

            _booksRepository.AddBooks(bookEntity); // This is a sync add

            await _booksRepository.SaveChangesAsync();

            return CreatedAtRoute("GetBook", new { id = bookEntity.Id }, bookEntity);

        }
    }
}