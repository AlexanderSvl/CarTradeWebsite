using CarTradeWebsite.Models;
using CarTradeWebsite.Models.Search;

namespace CarTradeWebsite.DataAccess.Repositories.Interfaces
{
    public interface ISearchRepository
    {
        Task<IEnumerable<PostModel>> SearchPosts(SearchParameters searchParameters);
    }
}
