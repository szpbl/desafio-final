using bibliotecaAPI.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bibliotecaAPI.Controllers.Responses
{
    public class SuccessResponse : IBaseResponse
    {
        public IActionResult CreateResponse(object result)
        {
            return new ObjectResult(new 
            {
                Status = "Sucesso",
                StatusCode = StatusCodes.Status200OK,
                Data = result
            });
        }
    }
}
