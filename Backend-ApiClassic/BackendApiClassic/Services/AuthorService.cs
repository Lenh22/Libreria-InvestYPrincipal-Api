using BackendApiClassic.Data;
using System.Data.Entity;
using BackendApiClassic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendApiClassic.Services
{
    public class AuthorService
    {
        private readonly LibraryDbContext _context;

        public AuthorService(LibraryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.Include(a => a.Books).ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
        }

        public Author Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public Author Update(int id, Author author)
        {
            var existing = _context.Authors.Find(id);
            if (existing == null) return null;

            existing.Name = author.Name;
            existing.BirthDate = author.BirthDate;
            existing.Nationality = author.Nationality;
            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var author = _context.Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
            if (author == null) return false;

            if (author.Books.Any())
                throw new InvalidOperationException("No se puede eliminar un autor con libros asociados.");

            _context.Authors.Remove(author);
            _context.SaveChanges();
            return true;
        }
    }
}
