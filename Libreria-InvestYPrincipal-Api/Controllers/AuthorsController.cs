using Microsoft.AspNetCore.Mvc;
using Libreria_InvestYPrincipal_Api.Models;
using Libreria_InvestYPrincipal_Api.Services;
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

        /// <summary>
        /// Obtiene todos los autores
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        /// <summary>
        /// Obtiene un autor por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        /// <summary>
        /// Crea un nuevo autor
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAuthor = await _authorService.CreateAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthor.Id }, createdAuthor);
        }

        /// <summary>
        /// Actualiza un autor existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedAuthor = await _authorService.UpdateAuthorAsync(id, author);
            if (updatedAuthor == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Elimina un autor
        /// </summary>
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
