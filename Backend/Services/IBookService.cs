using Libreria_InvestYPrincipal_Api.Models;

namespace Libreria_InvestYPrincipal_Api.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book?> UpdateBookAsync(int id, Book book);
        Task<bool> DeleteBookAsync(int id);
        Task<bool> BookExistsAsync(int id);
        Task<IEnumerable<Book>> SearchBooksAsync(string? title, string? genre, string? authorName);
    }
}
