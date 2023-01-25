using CarTradeWebsite.Models;

namespace CarTradeWebsite.DataAccess.Repositories.Interfaces
{
    public interface ISearchRepository
    {
        public Task<IEnumerable<PostModel>> SearchTitle(string title);
        public Task<IEnumerable<PostModel>> SearchDescription(string description);
        public Task<IEnumerable<PostModel>> SearchCarMake(string carMake);
        public Task<IEnumerable<PostModel>> SearchCarModel(string carModel);
        public Task<IEnumerable<PostModel>> SearchFuelType(string fuelType);
        public Task<IEnumerable<PostModel>> SearchEngineDisplacement(string motorDisplacement);
        public Task<IEnumerable<PostModel>> SearchTransmissionType(string transmissionType);
    }
}
