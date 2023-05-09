using CarTradeWebsite.Context;
using CarTradeWebsite.DataAccess.Repositories.Interfaces;
using CarTradeWebsite.Models;
using CarTradeWebsite.Models.Search;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarTradeWebsite.DataAccess.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private static DatabaseContext context = new DatabaseContext();

        public IEnumerable<PostModel> Search(SearchParameters searchParameters)
        {
            IEnumerable<PostModel> postsToReturn = Enumerable.Empty<PostModel>();

            if(searchParameters.Title != null)
            {

            }

            return postsToReturn.ToList();
        }

        public async Task<IEnumerable<PostModel>> SearchTitle(string titleKeywords)
        {
            return await context.Posts
                .Where(post => post.Title.Contains(titleKeywords))
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchDescription(string descriptionKeywords)
        {
            return await context.Posts
                .Where(post => post.Description.Contains(descriptionKeywords))
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchCarMake(string carMake)
        {
            return await context.Posts
                .Where(post => post.CarMake == carMake)
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchCarModel(string carModel)
        {
            return await context.Posts
                .Where(post => post.CarModel == carModel)
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchFuelType(string fuelType)
        {
            return await context.Posts
                .Where(post => post.FuelType == fuelType)
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchEngineDisplacement(string engineDisplacement)
        {
            return await context.Posts
                .Where(post => post.EngineDisplacement == engineDisplacement)
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchTransmissionType(string transmissionType)
        {
            return await context.Posts
                .Where(post => post.TransmissionType == transmissionType)
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchYearOfProduction(int startYear, int endYear)
        {
            return await context.Posts
                .Where(post => post.YearOfProduction >= startYear && post.YearOfProduction <= endYear)
                .Include(x => x.Options)
                .Include(y => y.CarImages)
                .ToListAsync();
        }
    }
}
