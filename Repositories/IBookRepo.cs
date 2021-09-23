using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksWebApi.Models;

namespace BooksWebApi.Repositories
{
    ///Interface that Repo or Service is to be implementing
    public interface IBookRepo
    {

        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<IEnumerable<Book>> GetBooksByIdAsync(string id);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
        Task<IEnumerable<Book>> GetBooksByTitleAsync(string title);
        Task<IEnumerable<Book>> GetBooksByGenreAsync(string genre);
        Task<IEnumerable<Book>> GetBooksByPriceAsync(double price);
        Task<IEnumerable<Book>> GetBooksByPriceBetweenAsync(double price1, double price2);
        Task<IEnumerable<Book>> GetBooksByDateAsync(int year, int month, int day);
        Task<IEnumerable<Book>> GetBooksByDescriptionAsync(string description);
    }
}
