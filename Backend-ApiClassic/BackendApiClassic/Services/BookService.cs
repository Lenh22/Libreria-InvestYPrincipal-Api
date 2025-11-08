using BackendApiClassic.Data;
using BackendApiClassic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity; 
using System.Linq;

namespace BackendApiClassic.Services
{
    public class BookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Include(b => b.Author).ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
        }

        public Book Create(Book book)
        {
            // Validar autor
            if (!_context.Authors.Any(a => a.Id == book.AuthorId))
                throw new Exception("El autor no existe.");

            // Validar ISBN único
            if (_context.Books.Any(b => b.ISBN == book.ISBN))
                throw new Exception("Ya existe un libro con el mismo ISBN.");

            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book Update(int id, Book book)
        {
            var existing = _context.Books.Find(id);
            if (existing == null) return null;

            // Validaciones
            if (!_context.Authors.Any(a => a.Id == book.AuthorId))
                throw new Exception("El autor no existe.");

            if (_context.Books.Any(b => b.ISBN == book.ISBN && b.Id != id))
                throw new Exception("Ya existe un libro con el mismo ISBN.");

            existing.Title = book.Title;
            existing.Genre = book.Genre;
            existing.PublishDate = book.PublishDate;
            existing.Pages = book.Pages;
            existing.Publisher = book.Publisher;
            existing.ISBN = book.ISBN;
            existing.Price = book.Price;
            existing.Language = book.Language;
            existing.AuthorId = book.AuthorId;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Book> Search(string title = null, string genre = null, string authorName = null)
        {
            var query = _context.Books.Include(b => b.Author).AsQueryable();

            if (!string.IsNullOrEmpty(title))
                query = query.Where(b => b.Title.Contains(title));

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(b => b.Genre.Contains(genre));

            if (!string.IsNullOrEmpty(authorName))
                query = query.Where(b => b.Author.Name.Contains(authorName));

            return query.ToList();
        }
    }
}
