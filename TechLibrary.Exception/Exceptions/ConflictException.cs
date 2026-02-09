using System.Net;

namespace TechLibrary.Exception.Exceptions;

public class ConflictException(string message) : TechLibraryException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public override IReadOnlyList<string> ErrorMessages { get; } = [message];
}
