using BackendApiClassic.Data;
using BackendApiClassic.Models;
using BackendApiClassic.Services;
using System.Linq;
using System.Web.Http;

namespace BackendApiClassic.Controllers
{
    [RoutePrefix("api/authors")]
    public class AuthorsController : ApiController
    {
        private readonly AuthorService _authorService;

        public AuthorsController()
        {
            var context = new LibraryDbContext();
            _authorService = new AuthorService(context);
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var authors = _authorService.GetAll();
            var dtos = authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name,
                BirthDate = a.BirthDate,
                Nationality = a.Nationality
            });
            return Ok(dtos);
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var author = _authorService.GetById(id);
            if (author == null)
                return NotFound();

            var dto = new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                BirthDate = author.BirthDate,
                Nationality = author.Nationality
            };
            return Ok(dto);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(AuthorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = new Author
            {
                Name = dto.Name,
                BirthDate = dto.BirthDate,
                Nationality = dto.Nationality
            };

            var created = _authorService.Create(author);
            dto.Id = created.Id;
            return Created($"api/authors/{dto.Id}", dto);
        }

        [HttpPut, Route("{id:int}")]
        public IHttpActionResult Update(int id, AuthorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var author = new Author
            {
                Id = id,
                Name = dto.Name,
                BirthDate = dto.BirthDate,
                Nationality = dto.Nationality
            };

            var updated = _authorService.Update(id, author);
            if (updated == null)
                return NotFound();

            return Ok();
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var author = _authorService.GetById(id);
            if (author == null)
                return NotFound();

            // Validación de libros asociados
            if (author.Books.Any())
                return BadRequest("No se puede eliminar un autor con libros asociados.");

            _authorService.Delete(id);
            return Ok();
        }
    }
}
