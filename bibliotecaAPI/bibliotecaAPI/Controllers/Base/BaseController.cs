using Microsoft.AspNetCore.Mvc;

namespace bibliotecaAPI.Controllers.Base
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        #region Methods

        protected IActionResult CreateCustomResponse<TResponse>(object result = null)
            where TResponse : IBaseResponse, new()
        {
            var response = new TResponse();

            return response.CreateResponse(result);
        }

        protected IActionResult CreateCustomNoContent()
        {
            return NoContent();
        }

        #endregion
    }
}
