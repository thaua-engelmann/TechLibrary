using TechLibrary.Application.Security;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Domain.Entities;
using TechLibrary.Domain.Repositories;
using TechLibrary.Domain.Repositories.Users;
using TechLibrary.Exception;
using TechLibrary.Exception.Exceptions;

namespace TechLibrary.Application.UseCases.Users.Create;

public class CreateUserUseCase(
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher,
    IUsersWriteOnlyRepository writeOnlyRepository,
    IUsersReadOnlyRepository readOnlyRepository) : ICreateUserUseCase
{
    public async Task<UserPostResponse> Execute(UserPostRequest request)
    {
        await Validate(request);

        var entity = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = passwordHasher.HashPassword(request.Password)
        };

        await writeOnlyRepository.Add(entity);
        await unitOfWork.Commit();

        return new UserPostResponse
        {
            Name = entity.Name,
            AccessToken = "MockedAccessToken"
        };
    }

    private async Task Validate(UserPostRequest request)
    {
        var validator = new CreateUserValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(validationFailure => validationFailure.ErrorMessage);
            throw new ErrorOnValidationException(errorMessages);
        }

        var isEmailUsed = await readOnlyRepository.EmailExistsAlready(request.Email);

        if (isEmailUsed)
        {
            throw new ConflictException(ResourceErrorMessages.EMAIL_EXISTS_ALREADY);
        }
    }
}
