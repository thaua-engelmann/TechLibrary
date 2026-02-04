using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.UseCases.Users.Create;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers;

public class UsersController : TechLibraryBaseController {

    [HttpPost]
    [ProducesResponseType(typeof(UserPostResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorMessagesResponse), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromServices] ICreateUserUseCase useCase, [FromBody] UserPostRequest request)
    {
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    } 

}