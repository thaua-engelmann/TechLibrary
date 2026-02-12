using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.UseCases.Auth.Login;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.Controllers;

public class AuthController(ILoginUseCase loginUseCase) : TechLibraryBaseController
{

    [HttpPost]
    public async Task<IActionResult> Login(LoginPostRequest request)
    {
        var response = await loginUseCase.Execute(request);
        return Ok(response);
    }

}
