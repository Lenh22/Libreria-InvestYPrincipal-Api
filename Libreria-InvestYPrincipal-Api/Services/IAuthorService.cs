using Libreria_InvestYPrincipal_Api.Models;

namespace Libreria_InvestYPrincipal_Api.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author?> GetAuthorByIdAsync(int id);
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author?> UpdateAuthorAsync(int id, Author author);
        Task<bool> DeleteAuthorAsync(int id);
        Task<bool> AuthorExistsAsync(int id);
    }
}
