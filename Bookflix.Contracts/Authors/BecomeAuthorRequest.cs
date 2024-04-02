namespace Bookflix.Contracts.Authors;

public record BecomeAuthorRequest(
    string? FirstName,
    string? LastName
);