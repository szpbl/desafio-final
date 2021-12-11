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
    public class AuthorsController : BaseController
    {

        #region Fields

        private readonly IAuthorsRepository _authorsRepository;

        #endregion

        #region Constructor

        public AuthorsController(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Authorize(Roles = UserRoles.All)]
        public async Task<IActionResult> ListAuthors()
        {
            try
            {
                var authors = await _authorsRepository.ListAuthorsAsync();

                if (authors == null)
                {
                    return CreateCustomResponse<NotFoundResponse>();
                }

                return CreateCustomResponse<SuccessResponse>(authors);

            }
            catch (Exception e)
            {

                return CreateCustomResponse<InternalServerErrorResponse>(e);
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddAuthor(AddAuthorInputModel inputData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CreateCustomResponse<BadRequestResponse>(ModelState);
                }

                Author newAuthor = new Author()
                {
                    Name = inputData.Name,
                    LastName = inputData.LastName,
                    CreatedIn = DateTime.Now
                };


                if (await _authorsRepository.AddAuthorAsync(newAuthor))
                {
                    return CreateCustomResponse<SuccessResponse>(newAuthor);
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

        #endregion
    }
}
