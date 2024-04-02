namespace Bookflix.Application.Common.Interfaces.Persistence
{
    public interface IAuthorRepository
    {
        Task<Guid?> GetIdentityGuid(int authorId);
    }
}