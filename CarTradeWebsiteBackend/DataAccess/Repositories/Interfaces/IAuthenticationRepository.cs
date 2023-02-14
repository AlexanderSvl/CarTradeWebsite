using CarTradeWebsite.Models;

namespace CarTradeWebsite.DataAccess.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<AuthenticatedResponseModel> Login(UserLoginModel user);
    }
}
