namespace Bookflix.Application.Authentication
{
    public record AuthenticationResult(
        int Id,
        Guid UserIdentityGuid,
        string Email,
        string FirstName,
        string LastName,
        string Token
    );
}