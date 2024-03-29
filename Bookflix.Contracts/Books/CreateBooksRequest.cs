namespace Bookflix.Contracts.Books
{
    public record CreateBookRequest(
        string Title,
        string Description,
        List<GenreRequest> Genres
    );

    public record GenreRequest(
        int GenreId
    );
}
