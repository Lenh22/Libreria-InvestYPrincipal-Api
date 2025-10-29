using Libreria_InvestYPrincipal_Api.Dto;
using Libreria_InvestYPrincipal_Api.Models;
using Libreria_InvestYPrincipal_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Libreria_InvestYPrincipal_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// Obtiene todos los libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            var bookDtos = books.Select(b => new BookDto
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
                AuthorName = b.Author != null ? b.Author.Name : string.Empty
            });

            return Ok(bookDtos);
        }

        /// Obtiene un libro por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = new BookDto
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
                AuthorName = book.Author != null ? book.Author.Name : string.Empty
            };

            return Ok(bookDto);
        }

        /// Busca libros con filtros opcionales
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<BookDto>>> SearchBooks(
            [FromQuery] string? title, 
            [FromQuery] string? genre, 
            [FromQuery] string? authorName)
        {
            var books = await _bookService.SearchBooksAsync(title, genre, authorName);
            var bookDtos = books.Select(b => new BookDto
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
                AuthorName = b.Author != null ? b.Author.Name : string.Empty
            });

            return Ok(bookDtos);
        }

        /// Crea un nuevo libro
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto bookDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Manda mensajes de error de validación
                }
                var book = new Book
                {
                    Title = bookDto.Title,
                    Genre = bookDto.Genre,
                    PublishDate = bookDto.PublishDate,
                    Pages = bookDto.Pages,
                    Publisher = bookDto.Publisher,
                    ISBN = bookDto.ISBN,
                    Price = bookDto.Price,
                    Language = bookDto.Language,
                    AuthorId = bookDto.AuthorId
                };

                var createdBook = await _bookService.CreateBookAsync(book);
                var createdBookDto = new BookDto
                {
                    Id = createdBook.Id,
                    Title = createdBook.Title,
                    Genre = createdBook.Genre,
                    PublishDate = createdBook.PublishDate,
                    Pages = createdBook.Pages,
                    Publisher = createdBook.Publisher,
                    ISBN = createdBook.ISBN,
                    Price = createdBook.Price,
                    Language = createdBook.Language,
                    AuthorId = createdBook.AuthorId,
                    AuthorName = createdBook.Author != null ? createdBook.Author.Name : string.Empty
                };
                return CreatedAtAction(nameof(GetBook), new { id = createdBookDto.Id }, createdBookDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// Actualiza un libro existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto dto)
        {

            if (id != dto.Id)
            {
                return BadRequest("El ID del libro no coincide con el parámetro.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = new Book
            {
                Id = dto.Id,
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
                var updatedBook = await _bookService.UpdateBookAsync(id, book);
                if (updatedBook == null)
                {
                    return NotFound("No se encontró el libro a actualizar.");
                }
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
        /// Elimina un libro
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var result = await _bookService.DeleteBookAsync(id);
                if (!result)
                    return NotFound(new { message = "Libro no encontrado." });

                return NoContent(); //204
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
