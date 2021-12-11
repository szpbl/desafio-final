using bibliotecaAPI.Context;
using bibliotecaAPI.Dados.Repositorios.Interfaces;
using bibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bibliotecaAPI.Dados.Repositorios
{
    public class BooksRepository : IBooksRepository
    {

        #region Fields

        private readonly LibraryDbContext _context;

        #endregion

        #region Constructor

        public BooksRepository(LibraryDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Book>> ListBooksAsync()
        {
            return await _context.Books.Include(x => x.Author).ToListAsync();
        }

        public async Task<bool> AddBookAsync(Book book)
        {
            _context.Books.Add(book);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateBookAsync(Book book)
        {

            _context.Books.Update(book);

            return await _context.SaveChangesAsync() == 1;

        }
        public async Task<Book> ObtainById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(Book livro)
        {
            _context.Remove(livro);

            return await _context.SaveChangesAsync() == 1;

        }

        public bool VerifyIfExists(int id)
        {
            return _context.Books.Any(c => c.Id == id);
        }

        #endregion

    }
}
