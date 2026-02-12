using TechLibrary.Application.Security.Interfaces;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Domain.Repositories.Users;
using TechLibrary.Exception;
using TechLibrary.Exception.Exceptions;

namespace TechLibrary.Application.UseCases.Auth.Login;

public class LoginUseCase(
    IUsersReadOnlyRepository usersReadOnlyRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenGenerator jwtTokenGenerator) : ILoginUseCase
{
    public async Task<LoginPostResponse> Execute(LoginPostRequest request)
    {
        var user = await usersReadOnlyRepository.GetByEmail(request.Email);

        if (user == null)
        {
            throw new UnauthorizedException(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID);
        }

        var isPasswordValid = passwordHasher.VerifyPassword(request.Password, user.Password);

        if (!isPasswordValid)
        {
            throw new UnauthorizedException(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID);
        }

        return new LoginPostResponse
        {
            Username = user.Name,
            Token = jwtTokenGenerator.Generate(user)
        };
    }

}
