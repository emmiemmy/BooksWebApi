using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BooksWebApi.DTOs;
using BooksWebApi.Models;
using BooksWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//api/books
    public class BooksController : ControllerBase
    {

        //To handle business logic
        private readonly IBookRepo _bookRepo;

        //Extension to handle mapping between model and dto
        private readonly IMapper _mapper;

        public BooksController(IBookRepo bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        /// Get all books, unsorted
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooksAsync()
        {
            try
            {
                IEnumerable<Book> books = await _bookRepo.GetAllBooksAsync();
                var result = _mapper.Map<BookDto[]>(books);

                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        ///Get all books, if applicable; containing {id?}, sorted by id
        [HttpGet("id/{id?}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByIdAsync(string id)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepo.GetBooksByIdAsync(id);
                var result = _mapper.Map<BookDto[]>(books);

                if(!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

         ///Get all books, if applicable; containing {author?}, sorted by author
        [HttpGet("author/{author?}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByAuthorAsync(string author)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepo.GetBooksByAuthorAsync(author);
                var result = _mapper.Map<BookDto[]>(books);

                if(!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

         ///Get all books, if applicable; containing {title?}, sorted by title
        [HttpGet("title/{title?}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByTitleAsync(string title)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepo.GetBooksByTitleAsync(title);
                var result = _mapper.Map<BookDto[]>(books);

                if(!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

         ///Get all books, if applicable; containing {genre?}, sorted by genre
        [HttpGet("genre/{genre?}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByGenreAsync(string genre)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepo.GetBooksByGenreAsync(genre);
                var result = _mapper.Map<BookDto[]>(books);

                if(!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

         ///Get all books, if applicable; containing {price?}, sorted by price
        [HttpGet("price/{price?}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByPriceAsync(double price)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepo.GetBooksByPriceAsync(price);
                var result = _mapper.Map<BookDto[]>(books);

                if(!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

         ///Get all books, if applicable; containing {price?}, sorted by price
        [HttpGet("price/{price1}&{price2}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByPriceBetweenAsync(double price1, double price2)
        {
            try
            {
                if(price1 !< 0 || price2 !< 0){
                    return BadRequest();
                }

                IEnumerable<Book> books = await _bookRepo.GetBooksByPriceBetweenAsync(price1, price2);
                var result = _mapper.Map<BookDto[]>(books);

                if(!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

         ///Get all books, if applicable; from {published?}, sorted by publishedDate
        [HttpGet("published/{year?}/{month?}/{day?}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByDateAsync(int year, int month, int day)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepo.GetBooksByDateAsync(year, month, day);
                var result = _mapper.Map<BookDto[]>(books);

                if(!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

         ///Get all books, if applicable; containing {description?}, sorted by description
        [HttpGet("description/{description?}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksByDescriptionAsync(string description)
        {
            try
            {
                IEnumerable<Book> books = await _bookRepo.GetBooksByDescriptionAsync(description);
                var result = _mapper.Map<BookDto[]>(books);

                if(!result.Any())
                {
                    return NoContent();
                }
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
