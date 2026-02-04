using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibrary.Exception.Exceptions;

namespace TechLibrary.Application.UseCases.Users.Create;

public class CreateUserUseCase : ICreateUserUseCase
{
    public UserPostResponse Execute(UserPostRequest request)
    {
        Validate(request);

        return new UserPostResponse
        {
            Name = request.Name,
            AccessToken = "mocked access token"
        };

    }

    private void Validate(UserPostRequest request)
    {
        var validator = new CreateUserValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(validationFailure => validationFailure.ErrorMessage);
            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
