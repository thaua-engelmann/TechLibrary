using System.Net;

namespace TechLibrary.Exception.Exceptions;
public abstract class TechLibraryException : SystemException
{
    public abstract HttpStatusCode StatusCode { get; }
    public abstract IReadOnlyList<string> ErrorMessages { get; }
}