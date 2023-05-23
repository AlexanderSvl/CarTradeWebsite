using CarTradeWebsite.Context;
using CarTradeWebsite.DataAccess.Repositories.Interfaces;
using CarTradeWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CarTradeWebsite.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static DatabaseContext context = new DatabaseContext();

        public async Task<PostModel> CreatePostAsync(PostModel post)
        {
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();

            return post;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            PostModel postToDelete = await context.Posts
                .Where(post => post.ID == postId)
                .Include(x => x.CarImages)
                .Include(x => x.Options)
                .FirstAsync();

            if (postToDelete != null)
            {
                context.Posts.Remove(postToDelete);
                await context.SaveChangesAsync();

                foreach (var image in postToDelete.CarImages)
                {
                    context.Images.Remove(image);
                    await context.SaveChangesAsync();
                }

                foreach (var option in postToDelete.Options)
                {
                    context.Options.Remove(option);
                    await context.SaveChangesAsync();
                }

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<PostModel>> GetAllPostsAsync()
        {
            return await context.Posts
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .ToListAsync();
        }

        public async Task<PostModel> GetPostByIdAsync(Guid postId)
        {
            return await context.Posts
                .Where(post => post.ID == postId)
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .FirstAsync();
        }

        public async Task<int> GetTotalPostsCountAsync()
        {
            return await context.Posts
                .CountAsync();
        }

        public async Task<PostModel?> EditPostAsync(Guid postID, PostModel post)
        {
            PostModel postToUpdate = await context.Posts
                .Where(p => p.ID == postID)
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .FirstAsync();

            if(postToUpdate != null)
            {
                postToUpdate.Title = post.Title;
                postToUpdate.Description = post.Description;
                postToUpdate.CarMake = post.CarMake;
                postToUpdate.CarModel = post.CarModel;
                postToUpdate.FuelType = post.FuelType;
                postToUpdate.EngineDisplacement = post.EngineDisplacement;
                postToUpdate.TransmissionType = post.TransmissionType;
                postToUpdate.CarImages = post.CarImages;
                postToUpdate.Options = post.Options;

                await context.SaveChangesAsync();
                return postToUpdate;
            }

            return null;
        }
    }
}
