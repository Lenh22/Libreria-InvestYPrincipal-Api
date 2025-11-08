using BackendApiClassic.Data;
using BackendApiClassic.Models;
using BackendApiClassic.Services;
using System;
using System.Linq;
using System.Web.Http;

namespace BackendApiClassic.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly BookService _bookService;

        // Inyección de dependencias si configurás Unity o similar
        public BooksController()
        {
            var context = new LibraryDbContext(); // EF6 DbContext
            _bookService = new BookService(context);
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetBooks()
        {
            var books = _bookService.GetAll();
            var dtos = books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Genre = b.Genre,
                PublishDate = b.PublishDate,
                Pages = b.Pages,
                Publisher = b.Publisher,
                ISBN = b.ISBN,
                Price = b.Price,
                Language = b.Language,
                AuthorId = b.AuthorId,
                AuthorName = b.Author?.Name ?? string.Empty
            });
            return Ok(dtos);
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult GetBook(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
                return NotFound();

            var dto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                Pages = book.Pages,
                Publisher = book.Publisher,
                ISBN = book.ISBN,
                Price = book.Price,
                Language = book.Language,
                AuthorId = book.AuthorId,
                AuthorName = book.Author?.Name ?? string.Empty
            };
            return Ok(dto);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(BookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = new Book
            {
                Title = dto.Title,
                Genre = dto.Genre,
                PublishDate = dto.PublishDate,
                Pages = dto.Pages,
                Publisher = dto.Publisher,
                ISBN = dto.ISBN,
                Price = dto.Price,
                Language = dto.Language,
                AuthorId = dto.AuthorId
            };

            try
            {
                var created = _bookService.Create(book);
                dto.Id = created.Id;
                dto.AuthorName = created.Author?.Name ?? string.Empty;
                return Created($"api/books/{dto.Id}", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Route("{id:int}")]
        public IHttpActionResult Update(int id, BookDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var book = new Book
            {
                Id = id,
                Title = dto.Title,
                Genre = dto.Genre,
                PublishDate = dto.PublishDate,
                Pages = dto.Pages,
                Publisher = dto.Publisher,
                ISBN = dto.ISBN,
                Price = dto.Price,
                Language = dto.Language,
                AuthorId = dto.AuthorId
            };

            try
            {
                var updated = _bookService.Update(id, book);
                if (updated == null)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var deleted = _bookService.Delete(id);
                if (!deleted)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
