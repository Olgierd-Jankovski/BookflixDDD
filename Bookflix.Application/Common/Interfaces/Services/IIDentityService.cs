namespace Bookflix.Application.Common.Interfaces.Services
{
    // interface for identity service
    public interface IIDentityService
    {
        /// <summary>
        ///  Get the user identity from the http context
        /// </summary>
        public int? GetUserId();

    }
}