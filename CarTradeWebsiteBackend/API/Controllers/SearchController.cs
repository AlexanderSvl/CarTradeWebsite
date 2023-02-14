using CarTradeWebsite.DataAccess.Repositories;
using CarTradeWebsite.DataAccess.Repositories.Interfaces;
using CarTradeWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarTradeWebsite.API.Controllers
{
    public class SearchController : ControllerBase
    {
        private ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            this._searchRepository = searchRepository;
        }

        [HttpGet("search/title")]
        public async Task<ActionResult<IEnumerable<PostModel>>> SearchTitle(string titleKeywords)
        {
            IEnumerable<PostModel> posts = await this._searchRepository.SearchTitle(titleKeywords);

            if(posts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("search/description")]
        public async Task<ActionResult<IEnumerable<PostModel>>> SearchDescription(string descriptionKeywords)
        {
            IEnumerable<PostModel> posts = await this._searchRepository.SearchDescription(descriptionKeywords);

            if (posts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("search/carMake")]
        public async Task<ActionResult<IEnumerable<PostModel>>> SearchCarMake(string carMake)
        {
            IEnumerable<PostModel> posts = await this._searchRepository.SearchCarMake(carMake);

            if (posts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("search/carModel")]
        public async Task<ActionResult<IEnumerable<PostModel>>> SearchCarModel(string carModel)
        {
            IEnumerable<PostModel> posts = await this._searchRepository.SearchCarModel(carModel);

            if (posts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("search/fuelType")]
        public async Task<ActionResult<IEnumerable<PostModel>>> SearchFuelType(string fuelType)
        {
            IEnumerable<PostModel> posts = await this._searchRepository.SearchFuelType(fuelType);

            if (posts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("search/engineDisplacement")]
        public async Task<ActionResult<IEnumerable<PostModel>>> SearchEngineDisplacement(string engineDisplacement)
        {
            IEnumerable<PostModel> posts = await this._searchRepository.SearchEngineDisplacement(engineDisplacement);

            if (posts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("search/transmissionType")]
        public async Task<ActionResult<IEnumerable<PostModel>>> SearchTransmissionType(string transmissionType)
        {
            IEnumerable<PostModel> posts = await this._searchRepository.SearchTransmissionType(transmissionType);

            if (posts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("search/yearOfProduction")]
        public async Task<ActionResult<IEnumerable<PostModel>>> SearchYearOfProduction(int start, int end)
        {
            IEnumerable<PostModel> posts = await this._searchRepository.SearchYearOfProduction(start, end);

            if (posts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(posts);
        }
    }
}
