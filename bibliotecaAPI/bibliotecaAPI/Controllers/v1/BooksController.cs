using bibliotecaAPI.Controllers.Base;
using bibliotecaAPI.Controllers.Responses;
using bibliotecaAPI.Dados.Repositorios.Interfaces;
using bibliotecaAPI.InputModels;
using bibliotecaAPI.Models;
using bibliotecaAPI.Services.Auth.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace bibliotecaAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = UserRoles.All)]

    public class BooksController : BaseController
    {
        #region Fields

        private readonly IBooksRepository _booksRepository;

        #endregion

        #region Constructor

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> ListBooks()
        {
            try
            {
                var books = await _booksRepository.ListBooksAsync();

                if (books == null)
                {
                    return CreateCustomResponse<NotFoundResponse>();
                }

                return CreateCustomResponse<SuccessResponse>(books);
            }
            catch (Exception e)
            {
                return CreateCustomResponse<InternalServerErrorResponse>(e);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BooksInputModel inputData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CreateCustomResponse<BadRequestResponse>(ModelState);
                }

                Book newBook = new Book(
                    inputData.Title, 
                    inputData.ISBN, 
                    inputData.PublishingYear, 
                    inputData.AuthorId
                    );

                if (await _booksRepository.AddBookAsync(newBook))
                {
                    return CreateCustomResponse<SuccessResponse>(newBook);
                }
                else
                {
                    return CreateCustomResponse<BadRequestResponse>();
                }





            }
            catch (Exception e)
            {

                return CreateCustomResponse<InternalServerErrorResponse>(e);
            }


        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _booksRepository.ObtainById(id);

            if (book == null)
            {
                return CreateCustomResponse<NotFoundResponse>("Book not found.");
            }

            await _booksRepository.DeleteAsync(book);

            return CreateCustomResponse<NoContentResponse>();
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookInputModel inputData)
        {
            try
            {
                if (id != inputData.Id)
                {
                    return CreateCustomResponse<BadRequestResponse>("Invalid Id.");
                }

                var book = await _booksRepository.ObtainById(id);

                if (book == null)
                {
                    return CreateCustomResponse<NotFoundResponse>();
                }

                book.SetTitle(inputData.Title);
                book.SetPublishingYear(inputData.PublishingYear);

                if (await _booksRepository.UpdateBookAsync(book))
                {
                    return CreateCustomResponse<SuccessResponse>(book);
                } else
                {
                    return CreateCustomResponse<BadRequestResponse>();
                }
            }
            catch (Exception e)
            {

                if (!_booksRepository.VerifyIfExists(inputData.Id))
                {
                    return CreateCustomResponse<NotFoundResponse>();
                } else
                {
                    return CreateCustomResponse<InternalServerErrorResponse>(e);
                }
            }


        }


        #endregion

    }
}
