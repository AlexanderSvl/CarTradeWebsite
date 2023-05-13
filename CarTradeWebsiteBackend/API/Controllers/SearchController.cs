using CarTradeWebsite.DataAccess.Repositories;
using CarTradeWebsite.DataAccess.Repositories.Interfaces;
using CarTradeWebsite.Models;
using CarTradeWebsite.Models.Search;
using Microsoft.AspNetCore.Mvc;

namespace CarTradeWebsite.API.Controllers
{
    public class SearchController : ControllerBase
    {
        private ISearchRepository _searchRepository { get; set; }

        public SearchController(ISearchRepository searchRepository)
        {
            this._searchRepository = searchRepository;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PostModel>>> Search(SearchParameters searchParameters)
        {
            IEnumerable<PostModel> posts = await this._searchRepository.SearchPosts(searchParameters);

            if (posts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(posts);
        }
    }
}
