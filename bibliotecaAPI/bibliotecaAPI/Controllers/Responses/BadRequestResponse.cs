using bibliotecaAPI.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace bibliotecaAPI.Controllers.Responses
{
    public class BadRequestResponse : IBaseResponse
    {
        public IActionResult CreateResponse(object result)
        {
            IEnumerable<string> errors = null;

            if (result is ModelStateDictionary dictionary)
            {
                errors = dictionary.Values.SelectMany(e => e.Errors).Select(c => c.ErrorMessage);
            }

            return new NotFoundObjectResult(new FailResponse(StatusCodes.Status400BadRequest, errors ?? result));
        }
    }
}
