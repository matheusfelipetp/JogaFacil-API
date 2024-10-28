using JogaFacil.Application.UseCases.Users.Delete;
using JogaFacil.Application.UseCases.Users.GetAll;
using JogaFacil.Application.UseCases.Users.GetById;
using JogaFacil.Application.UseCases.Users.Register;
using JogaFacil.Application.UseCases.Users.Update;
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
        [ProducesResponseType(typeof(ResponseUsersJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetAllUserUseCase useCase
            )
        {
            var response = await useCase.Execute();
            
            if (response is null)
                return NoContent();
            
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(
            [FromServices] IGetByIdUserUseCase useCase,
            [FromRoute] Guid id
            )
        {
            var response = await useCase.Execute(id);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(
            [FromServices] IUpdateUserUseCase useCase,
            [FromRoute] Guid id,
            [FromBody] RequestUpdateUserJson request
            )
        {
            await useCase.Execute(id, request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(
            [FromServices] IDeleteUserUseCase useCase,
            [FromRoute] Guid id
            )
        {
            await useCase.Execute(id);
            return NoContent();
        }
    }
}
