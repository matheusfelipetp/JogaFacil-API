using JogaFacil.Application.UseCases.Login;
using JogaFacil.Comunication.Requests.Login;
using JogaFacil.Comunication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace JogaFacil.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
            [FromServices] ILoginUseCase useCase,
            [FromBody] RequestLoginJson request
            )
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }
    }
}
