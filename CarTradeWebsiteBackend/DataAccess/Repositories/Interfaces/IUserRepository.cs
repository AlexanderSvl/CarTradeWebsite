using Microsoft.AspNetCore.Mvc;

namespace CarTradeWebsite.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> GetUsersAsync();
        Task<UserModel> CreateUserAsync(UserModel user);
        Task<UserModel> EditUserAsync(Guid userId, UserModel user);
        Task<bool> DeleteUserAsync(Guid ID);
        Task<UserModel> GetUserByIDAsync(Guid ID);
        Task<int> GetTotalUsersCountAsync();
    }
}
