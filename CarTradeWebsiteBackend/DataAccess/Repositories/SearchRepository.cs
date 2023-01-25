using CarTradeWebsite.Context;
using CarTradeWebsite.DataAccess.Repositories.Interfaces;
using CarTradeWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace CarTradeWebsite.DataAccess.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private static DatabaseContext context = new DatabaseContext();

        public async Task<IEnumerable<PostModel>> SearchTitle(string titleKeywords)
        {
            return await context.Posts
                .Where(post => post.Title.Contains(titleKeywords))
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchDescription(string descriptionKeywords)
        {
            return await context.Posts
                .Where(post => post.Description.Contains(descriptionKeywords))
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchCarMake(string carMake)
        {
            return await context.Posts
                .Where(post => post.CarMake == carMake)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchCarModel(string carModel)
        {
            return await context.Posts
                .Where(post => post.CarModel == carModel)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchFuelType(string fuelType)
        {
            return await context.Posts
                .Where(post => post.FuelType == fuelType)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchEngineDisplacement(string engineDisplacement)
        {
            return await context.Posts
                .Where(post => post.EngineDisplacement == engineDisplacement)
                .ToListAsync();
        }

        public async Task<IEnumerable<PostModel>> SearchTransmissionType(string transmissionType)
        {
            return await context.Posts
                .Where(post => post.TransmissionType == transmissionType)
                .ToListAsync();
        }
    }
}
