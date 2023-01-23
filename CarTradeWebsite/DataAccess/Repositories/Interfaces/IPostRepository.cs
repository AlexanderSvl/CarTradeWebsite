using CarTradeWebsite.Models;

namespace CarTradeWebsite.DataAccess.Repositories.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<PostModel>> GetAllPostsAsync();
        Task<PostModel> GetPostByIdAsync(Guid postId);
        Task<PostModel> CreatePostAsync(PostModel post);
        Task<PostModel?> EditPostAsync(Guid postID, PostModel post);
        Task<bool> DeletePostAsync(Guid postId);
        Task<int> GetTotalPostsCountAsync();
    }
}
