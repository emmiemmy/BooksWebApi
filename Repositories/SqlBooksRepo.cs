using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksWebApi.Contexts;
using BooksWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApi.Repositories
{
    //Accessing data through DbContext
    public class SqlBooksRepo : IBookRepo
    {
        private readonly BooksApiDbContext _context;

        //Map DbContext field to relevant data, e.g. Books table
        public SqlBooksRepo(BooksApiDbContext context)
        {
            _context = context;
        }

        //Get all books, unordered
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        //Get all books, sorted by Id. If id parameter is defined, filter on id
        public async Task<IEnumerable<Book>> GetBooksByIdAsync(string id)
        {
            IQueryable<Book> query = _context.Books;
            //if serach parameter is defined
            if (!string.IsNullOrEmpty(id))
            {
                query = query.Where(b => b.Id.Contains(id)); //Seems like Contains is case insensitive?!
            }
            query = query.OrderBy(b => b.Id);

            return await query.ToListAsync();
        }

        //Get all books, ordered by author. If author search parameter id defined, apply filter
        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
        {
            IQueryable<Book> query = _context.Books;
            //if serach parameter is defined
            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(b => b.Author.Contains(author));
            }
            query = query.OrderBy(b => b.Author);

            return await query.ToListAsync();
        }

        //Get all books, ordered by Title. If title search parameter id defined, apply filter
        public async Task<IEnumerable<Book>> GetBooksByTitleAsync(string title)
        {
            IQueryable<Book> query = _context.Books;
            //if serach parameter is defined
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }
            query = query.OrderBy(b => b.Title);

            return await query.ToListAsync();
        }

        //Get all books, ordered by Genre. If genre search parameter id defined, apply filter
        public async Task<IEnumerable<Book>> GetBooksByGenreAsync(string genre)
        {
            IQueryable<Book> query = _context.Books;
            //if serach parameter is defined
            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(b => b.Genre.Contains(genre));
            }
            query = query.OrderBy(b => b.Genre);

            return await query.ToListAsync();
        }

        //Get all books, ordered by Price. If price search parameter id defined, apply filter
        public async Task<IEnumerable<Book>> GetBooksByPriceAsync(double price)
        {
            IQueryable<Book> query = _context.Books;
            //if serach parameter is defined
            if (price != 0)
            {
                query = query.Where(b => b.Price.Equals(price));
            }
            query = query.OrderBy(b => b.Price);

            return await query.ToListAsync();
        }

        //Get all books, ordered by Price. Filter on price between defined parameters
        public async Task<IEnumerable<Book>> GetBooksByPriceBetweenAsync(double price1, double price2)
        {
            IQueryable<Book> query = _context.Books;
            
            ///Check what price is low vs high
            var min = Math.Min(price1, price2);
            var max = Math.Max(price1, price2);

            query = query.Where(b => b.Price >= min).Where(b => b.Price <= max);
            query = query.OrderBy(b => b.Price);

            return await query.ToListAsync();
        }

        //Get all books, ordered by Date. Filter on date between defined parameters
        public async Task<IEnumerable<Book>> GetBooksByDateAsync(int year, int month, int day)
        {
            ///TODO fix logic... better...
            IQueryable<Book> query = _context.Books;
            if (year != 0 && month != 0 && day != 0)
            {
                query = query.Where(b => b.PublishDate.Year == year && b.PublishDate.Month == month && b.PublishDate.Day == day);
            }
            else if (year != 0 && month != 0)
            {
                query = query.Where(b => b.PublishDate.Year == year && b.PublishDate.Month == month);
            }
            else if (year != 0)
            {
                query = query.Where(b => b.PublishDate.Year == year);
            }
            query = query.OrderBy(b => b.PublishDate);


            return await query.ToListAsync();
        }

        //Get all books, ordered by Description. If description search parameter id defined, apply filter
        public async Task<IEnumerable<Book>> GetBooksByDescriptionAsync(string description)
        {
            IQueryable<Book> query = _context.Books;
            //if serach parameter is defined
            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(b => b.Description.Contains(description));
            }
            query = query.OrderBy(b => b.Description);

            return await query.ToListAsync();
        }
    }
}
