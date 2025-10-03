using Microsoft.AspNetCore.Mvc;
using Libreria_InvestYPrincipal_Api.Models;
using Libreria_InvestYPrincipal_Api.Services;

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

        /// <summary>
        /// Obtiene todos los libros
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        /// <summary>
        /// Obtiene un libro por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        /// <summary>
        /// Busca libros con filtros opcionales
        /// </summary>
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBooks(
            [FromQuery] string? title, 
            [FromQuery] string? genre, 
            [FromQuery] string? authorName)
        {
            var books = await _bookService.SearchBooksAsync(title, genre, authorName);
            return Ok(books);
        }

        /// <summary>
        /// Crea un nuevo libro
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBook = await _bookService.CreateBookAsync(book);
            return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
        }

        /// <summary>
        /// Actualiza un libro existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedBook = await _bookService.UpdateBookAsync(id, book);
            if (updatedBook == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Elimina un libro
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
