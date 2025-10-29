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
                .Include(b => b.Author)
                .ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            ValidateBook(book);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateBookAsync(int id, Book book)
        {

            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
                return null;

            ValidateBook(book, isUpdate: true);

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
                throw new ArgumentException("No se ha encontrado el libro en la base de datos.");

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
            var query = _context.Books.Include(b => b.Author).AsQueryable();

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
                query = query.Where(b => b.Author.Name.Contains(authorName));
            }

            return await query.ToListAsync();
        }
        private void ValidateBook(Book book, bool isUpdate = false)
        {
            //Verificar ISBN unico
            var isbnExists = _context.Books.Any(b => b.ISBN == book.ISBN && (!isUpdate || b.Id != book.Id));

            if (isbnExists)
                throw new ArgumentException("Ya existe un libro con el mismo ISBN.");

            if (book.PublishDate > DateTime.Today)
                throw new ArgumentException("La fecha de publicacion no puede ser futura.");

            if (book.AuthorId <= 0)
                throw new ArgumentException("Debe especificar un autor valido.");

            var authorExists = _context.Authors.Any(a => a.Id == book.AuthorId);
            if (!authorExists)
                throw new ArgumentException("El autor no existe en la base de datos.");
        }
    }
}
