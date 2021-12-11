using bibliotecaAPI.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bibliotecaAPI.Controllers.Responses
{
    public class NoContentResponse : IBaseResponse
    {
        public IActionResult CreateResponse(object result = null)
        {
            return new ObjectResult(new
            {
                Status = "Success",
                StatusCode = StatusCodes.Status204NoContent,
                Result = result
            });
        }
    }
}
