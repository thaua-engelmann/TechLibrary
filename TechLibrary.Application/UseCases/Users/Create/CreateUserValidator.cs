using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Application.UseCases.Users.Create;

internal class CreateUserValidator : AbstractValidator<UserPostRequest>
{
    public CreateUserValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(request => request.Email).NotEmpty().WithMessage("Email is required.")
                                        .EmailAddress().WithMessage("A valid email is required.");
        When(request => string.IsNullOrEmpty(request.Password) == false, () => {
            RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(8).WithMessage("Password must be at least 8 characters long.");
        });
    }
}
