using CarTradeWebsite.DataAccess.Repositories.Interfaces;
using CarTradeWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarTradeWebsite.API.Controllers
{
    public class PostController : ControllerBase
    {
        private IPostRepository _postRepository { get; set; }

        public PostController(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
        }

        [HttpGet("posts/get")]
        public async Task<ActionResult<IEnumerable<PostModel>>> GetAllPosts()
        {
            IEnumerable<PostModel> posts = await this._postRepository.GetAllPostsAsync();

            if (posts == null || posts.Count() == 0)
            {
                return NoContent();
            }

            return Ok(posts);
        }

        [HttpGet("posts/count")]
        public async Task<ActionResult<int>> GetAllPostsCount()
        {
            int count = await this._postRepository.GetTotalPostsCountAsync();

            return Ok(count);
        }

        [HttpPost("posts/new")]
        public async Task<ActionResult<PostModel>> CreatePost([FromBody] PostModel post)
        {
            PostModel createdPost = await this._postRepository.CreatePostAsync(post);

            if (createdPost == null)
            {
                return BadRequest();
            }

            return Ok(createdPost);
        }

        [HttpGet("posts/get/{ID}")]
        public async Task<ActionResult<PostModel>> GetPostById(Guid ID)
        {
            PostModel post = await this._postRepository.GetPostByIdAsync(ID);

            if(post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPut("posts/{postId}/edit")]
        public async Task<ActionResult<PostModel?>> EditPost(Guid postId, PostModel post)
        {
            PostModel postToUpdate = await this._postRepository.EditPostAsync(postId, post);

            if(postToUpdate == null)
            {
                return BadRequest();
            }

            return Ok(postToUpdate);
        }

        [HttpDelete("posts/{postId}/delete")]
        public async Task<ActionResult<bool>> DeletePost(Guid postId)
        {
            bool isDeleted = await this._postRepository.DeletePostAsync(postId);

            if (!isDeleted)
            {
                return NotFound(postId);
            }

            return Ok();
        }
    }
}
