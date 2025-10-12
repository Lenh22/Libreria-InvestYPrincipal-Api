using Libreria_InvestYPrincipal_Api.Dto;
using Libreria_InvestYPrincipal_Api.Models;
using Libreria_InvestYPrincipal_Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Libreria_InvestYPrincipal_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// Obtiene todos los autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();

            // Mapeo manual (puedes reemplazar por AutoMapper)
            var authorsDto = authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                BirthDate = a.BirthDate,
                Nationality = a.Nationality
            });

            return Ok(authorsDto);
        }

        /// Obtiene un autor por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorDto = new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                BirthDate = author.BirthDate,
                Nationality = author.Nationality
            };

            return Ok(authorDto);
        }

        /// Crea un nuevo autor
        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var author = new Author
            {
                Name = authorDto.Name,
                BirthDate = authorDto.BirthDate,
                Nationality = authorDto.Nationality
            };

            var createdAuthor = await _authorService.CreateAuthorAsync(author);

            var createdAuthorDto = new AuthorDto
            {
                Id = createdAuthor.Id,
                Name = createdAuthor.Name,
                BirthDate = createdAuthor.BirthDate,
                Nationality = createdAuthor.Nationality
            };

            return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthorDto.Id }, createdAuthorDto);
        }

        /// Actualiza un autor existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, AuthorDto authorDto)
        {
            if (id != authorDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var author = new Author
            {
                Id = authorDto.Id,
                Name = authorDto.Name,
                BirthDate = authorDto.BirthDate,
                Nationality = authorDto.Nationality
            };
            var updatedAuthor = await _authorService.UpdateAuthorAsync(id, author);
            if (updatedAuthor == null)
                return NotFound();

            return NoContent();
        }

        /// Elimina un autor
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteAuthorAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
