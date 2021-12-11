using biblioteca.Data.Repositories.Interfaces;
using bibliotecaAPI.Adapters;
using bibliotecaAPI.Controllers.Base;
using bibliotecaAPI.Controllers.Responses;
using bibliotecaAPI.InputModels;
using bibliotecaAPI.Services.Auth.Jwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bibliotecaAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : BaseController
    {

        #region Fields

        private readonly IJwtAuthManager _jwtAuthGerenciador;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructor

        public AuthController(IJwtAuthManager jwtAuthManager, IUserRepository userRepository)
        {
            _jwtAuthGerenciador = jwtAuthManager;
            _userRepository = userRepository;
        }

        #endregion

        #region Methods

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Aunthenticate(UserInputModel jwtCredentials)
        {
            try
            {
                var currentUser = await _userRepository.ReturnByCredentials(jwtCredentials.Email, jwtCredentials.Password);

                if (!ModelState.IsValid)
                {
                    return CreateCustomResponse<BadRequestResponse>(ModelState);
                }

                if (currentUser == null)
                {
                    return CreateCustomResponse<NotFoundResponse>();
                }

                var credentials = ModelAdapters.ToJwtCredentials(currentUser);

                return CreateCustomResponse<SuccessResponse>(_jwtAuthGerenciador.GenerateToken(credentials));

            }
            catch (System.Exception e)
            {

                return CreateCustomResponse<InternalServerErrorResponse>(e);
            }
        } 

        #endregion
    }
}
