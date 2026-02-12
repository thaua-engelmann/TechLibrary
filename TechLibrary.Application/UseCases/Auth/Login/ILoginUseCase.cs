using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Application.UseCases.Auth.Login;

public interface ILoginUseCase
{
    public Task<LoginPostResponse> Execute(LoginPostRequest request);
}
