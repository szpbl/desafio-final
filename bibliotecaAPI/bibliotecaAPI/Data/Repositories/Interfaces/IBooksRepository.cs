using bibliotecaAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bibliotecaAPI.Dados.Repositorios.Interfaces
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> ListBooksAsync();
        Task<Book> ObtainById(int id);
        Task<bool> AddBookAsync(Book book);
        Task<bool> DeleteAsync(Book book);
        Task<bool> UpdateBookAsync(Book book);
        bool VerifyIfExists(int id);
    }
}
