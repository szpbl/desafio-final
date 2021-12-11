using Microsoft.AspNetCore.Mvc;

namespace bibliotecaAPI.Controllers.Base
{
    public interface IBaseResponse
    {
        IActionResult CreateResponse(object result);
    }
}
