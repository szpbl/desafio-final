using biblioteca.Data.Repositories.Interfaces;
using bibliotecaAPI.Controllers.Base;
using bibliotecaAPI.Controllers.Responses;
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
    [Authorize(Roles = UserRoles.Admin)]
    public class UsersController : BaseController
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructor
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserInputModel inputData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return CreateCustomResponse<BadRequestResponse>(ModelState);
                }

                User newUser = new User()
                {
                    Name = inputData.Name,
                    Email = inputData.Email,
                    Password = inputData.Password,
                    RoleId = inputData.RoleId,
                    CreatedIn = DateTime.Now
                };

                if (await _userRepository.AddAsync(newUser))
                {
                    return CreateCustomResponse<SuccessResponse>(newUser);
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
