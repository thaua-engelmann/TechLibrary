using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories;
using TechLibrary.Domain.Repositories.Users;
using TechLibrary.Exception;
using TechLibrary.Exception.Exceptions;

namespace TechLibrary.Application.UseCases.Users.Create;

public class CreateUserUseCase(IUsersWriteOnlyRepository repository, IUnitOfWork unitOfWork) : ICreateUserUseCase
{
    public async Task<UserPostResponse> Execute(UserPostRequest request)
    {
        Validate(request);

        var entity = new User { Name = request.Name };
        await repository.Add(entity);
        await unitOfWork.Commit();

        return new UserPostResponse
        {
            Name = entity.Name,
            AccessToken = "MockedAccessToken"
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
