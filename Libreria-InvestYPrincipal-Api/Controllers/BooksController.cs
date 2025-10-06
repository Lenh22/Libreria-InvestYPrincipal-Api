using Microsoft.AspNetCore.Mvc;
using Libreria_InvestYPrincipal_Api.Models;
using Libreria_InvestYPrincipal_Api.Services;
using Libreria_InvestYPrincipal_Api.Dto;

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
        public async Task<ActionResult<ApiResponse<IEnumerable<BookDto>>>> GetBooks()
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
                Author = b.Author != null ? new AuthorDto
                {
                    Id = b.Author.Id,
                    Name = b.Author.Name,
                    BirthDate = b.Author.BirthDate,
                    Nationality = b.Author.Nationality
                } : null
            });
            return Ok(ApiResponse<IEnumerable<BookDto>>.SuccessResponse(bookDtos, "Libros obtenidos exitosamente"));
        }

        /// Obtiene un libro por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<BookDto>>> GetBook(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound(ApiResponse<BookDto>.ErrorResponse("Libro no encontrado"));
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
                Author = book.Author != null ? new AuthorDto
                {
                    Id = book.Author.Id,
                    Name = book.Author.Name,
                    BirthDate = book.Author.BirthDate,
                    Nationality = book.Author.Nationality
                } : null
            };
            
            return Ok(ApiResponse<BookDto>.SuccessResponse(bookDto, "Libro obtenido exitosamente"));
        }

        /// Busca libros con filtros opcionales
        [HttpGet("search")]
        public async Task<ActionResult<ApiResponse<IEnumerable<BookDto>>>> SearchBooks(
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
                Author = b.Author != null ? new AuthorDto
                {
                    Id = b.Author.Id,
                    Name = b.Author.Name,
                    BirthDate = b.Author.BirthDate,
                    Nationality = b.Author.Nationality
                } : null
            });
            return Ok(ApiResponse<IEnumerable<BookDto>>.SuccessResponse(bookDtos, "Búsqueda completada exitosamente"));
        }

        /// Crea un nuevo libro
        [HttpPost]
        public async Task<ActionResult<ApiResponse<BookDto>>> CreateBook(BookCreateDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<BookDto>.ErrorResponse("Datos de entrada inválidos"));
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
                AuthorId = createdBook.AuthorId
            };
            
            return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, 
                ApiResponse<BookDto>.SuccessResponse(createdBookDto, "Libro creado exitosamente"));
        }

        /// Actualiza un libro existente
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateBook(int id, BookUpdateDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse.ErrorResponse("Datos de entrada inválidos"));
            }

            var book = new Book
            {
                Id = id,
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

            var updatedBook = await _bookService.UpdateBookAsync(id, book);
            if (updatedBook == null)
            {
                return NotFound(ApiResponse.ErrorResponse("Libro no encontrado"));
            }

            return Ok(ApiResponse.SuccessResponse("Libro actualizado exitosamente"));
        }

        /// Elimina un libro
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result)
            {
                return NotFound(ApiResponse.ErrorResponse("Libro no encontrado"));
            }

            return Ok(ApiResponse.SuccessResponse("Libro eliminado exitosamente"));
        }

    }
}
