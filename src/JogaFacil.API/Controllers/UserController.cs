using JogaFacil.Application.UseCases.Users.GetAll;
using JogaFacil.Application.UseCases.Users.Register;
using JogaFacil.Comunication.Requests.Users;
using JogaFacil.Comunication.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogaFacil.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody] RequestRegisterUserJson request
            )
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllUserUseCase useCase
            )
        {
            var response = await useCase.Execute();
            
            if (response is null)
                return NoContent();

            return Ok(response);
        }
    }
}
