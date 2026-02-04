namespace TechLibrary.Communication.Responses;

public class ErrorMessagesResponse
{
    public IReadOnlyList<string> Messages { get; }

    public ErrorMessagesResponse(string error)
    {
        Messages = [error];
    }

    public ErrorMessagesResponse(IEnumerable<string> errors)
    {
        Messages = errors.ToList().AsReadOnly();
    }
}
