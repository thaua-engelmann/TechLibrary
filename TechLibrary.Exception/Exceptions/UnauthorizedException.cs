using System.Net;

namespace TechLibrary.Exception.Exceptions;

public class UnauthorizedException(string message) : TechLibraryException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    public override IReadOnlyList<string> ErrorMessages { get; } = [message];
}
