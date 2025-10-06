using Microsoft.AspNetCore.Mvc;
using Libreria_InvestYPrincipal_Api.Models;
using Libreria_InvestYPrincipal_Api.Services;
using Libreria_InvestYPrincipal_Api.Dto;
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
        public async Task<ActionResult<ApiResponse<IEnumerable<AuthorDto>>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            var authorDtos = authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                BirthDate = a.BirthDate,
                Nationality = a.Nationality
            });
            return Ok(ApiResponse<IEnumerable<AuthorDto>>.SuccessResponse(authorDtos, "Autores obtenidos exitosamente"));
        }

        /// Obtiene un autor por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<AuthorDto>>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound(ApiResponse<AuthorDto>.ErrorResponse("Autor no encontrado"));
            }
            
            var authorDto = new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                BirthDate = author.BirthDate,
                Nationality = author.Nationality
            };
            
            return Ok(ApiResponse<AuthorDto>.SuccessResponse(authorDto, "Autor obtenido exitosamente"));
        }

        /// Crea un nuevo autor
        [HttpPost]
        public async Task<ActionResult<ApiResponse<AuthorDto>>> CreateAuthor(AuthorCreateDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<AuthorDto>.ErrorResponse("Datos de entrada inválidos"));
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
            
            return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthor.Id }, 
                ApiResponse<AuthorDto>.SuccessResponse(createdAuthorDto, "Autor creado exitosamente"));
        }

        /// Actualiza un autor existente
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateAuthor(int id, AuthorUpdateDto authorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse.ErrorResponse("Datos de entrada inválidos"));
            }

            var author = new Author
            {
                Id = id,
                Name = authorDto.Name,
                BirthDate = authorDto.BirthDate,
                Nationality = authorDto.Nationality
            };

            var updatedAuthor = await _authorService.UpdateAuthorAsync(id, author);
            if (updatedAuthor == null)
            {
                return NotFound(ApiResponse.ErrorResponse("Autor no encontrado"));
            }

            return Ok(ApiResponse.SuccessResponse("Autor actualizado exitosamente"));
        }

        /// Elimina un autor
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteAuthorAsync(id);
            if (!result)
            {
                return NotFound(ApiResponse.ErrorResponse("Autor no encontrado"));
            }

            return Ok(ApiResponse.SuccessResponse("Autor eliminado exitosamente"));
        }
    }
}
