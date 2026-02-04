using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Application.UseCases.Users.Create;
public interface ICreateUserUseCase
{
    public UserPostResponse Execute(UserPostRequest request);
}
