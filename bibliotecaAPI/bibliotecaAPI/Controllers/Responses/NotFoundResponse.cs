using bibliotecaAPI.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bibliotecaAPI.Controllers.Responses
{
    public class NotFoundResponse : IBaseResponse
    {
        public IActionResult CreateResponse(object result = null)
        {
            if (result == null)
            {
                result = "Not found.";
            }

            return new NotFoundObjectResult(new FailResponse(StatusCodes.Status404NotFound, result));
        }
    }
}
