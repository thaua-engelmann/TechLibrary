namespace TechLibrary.Communication.Requests;

public class LoginPostRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
