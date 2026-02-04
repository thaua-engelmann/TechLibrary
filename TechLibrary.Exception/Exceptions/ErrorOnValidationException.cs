using System.Net;

namespace TechLibrary.Exception.Exceptions;

public class ErrorOnValidationException : TechLibraryException
{

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public override IReadOnlyList<string> ErrorMessages { get; }

    public ErrorOnValidationException(IEnumerable<string> messages)
    {
        ErrorMessages = messages.ToList().AsReadOnly();
    }
}
