using Libreria_InvestYPrincipal_Api.Data;
using Libreria_InvestYPrincipal_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria_InvestYPrincipal_Api.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                .ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateBookAsync(int id, Book book)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
                return null;

            existingBook.Title = book.Title;
            existingBook.Genre = book.Genre;
            existingBook.PublishDate = book.PublishDate;
            existingBook.Pages = book.Pages;
            existingBook.Publisher = book.Publisher;
            existingBook.ISBN = book.ISBN;
            existingBook.Price = book.Price;
            existingBook.Language = book.Language;
            existingBook.AuthorId = book.AuthorId;

            await _context.SaveChangesAsync();
            return existingBook;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> BookExistsAsync(int id)
        {
            return await _context.Books.AnyAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> SearchBooksAsync(string? title, string? genre, string? authorName)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(b => b.Genre.Contains(genre));
            }

            if (!string.IsNullOrEmpty(authorName))
            {
                // Buscar nombre de autor se necesita Joins
                query = query.Where(b => _context.Authors.Any(a => a.Id == b.AuthorId && a.Name.Contains(authorName)));
            }

            return await query.ToListAsync();
        }
    }
}
