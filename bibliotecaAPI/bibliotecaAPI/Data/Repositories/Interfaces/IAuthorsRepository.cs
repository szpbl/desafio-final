using bibliotecaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bibliotecaAPI.Dados.Repositorios.Interfaces
{
    public interface IAuthorsRepository
    {
        Task<IEnumerable<Author>> ListAuthorsAsync();
        Task<bool> AddAuthorAsync(Author author); 
    }
}
