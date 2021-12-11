using bibliotecaAPI.Configuration;
using bibliotecaAPI.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace bibliotecaAPI.Controllers.Responses
{
    public class InternalServerErrorResponse : IBaseResponse
    {
        public IActionResult CreateResponse(object result = null)
        {
            string errorMessages;

            if (result is Exception exception)
            {
                errorMessages = exception.ReturnAllMessages();
            }
            else
            {
                errorMessages = result.ToString();
            }

            var internalServerError = new ObjectResult(new ErrorResponse(StatusCodes.Status500InternalServerError, errorMessages))
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            return internalServerError;
        }
    }
}
