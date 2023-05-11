using System.ComponentModel.DataAnnotations;

namespace CarTradeWebsite.Models.Search
{
    public class SearchParameters
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? CarMake { get; set; }
        public string? CarModel { get; set; }
        public string? TransmissionType { get; set; }
        public string? FuelType { get; set; }
        public string? EngineDisplacement { get; set; }
        public string? Color { get; set; }
        public int? StartYearOfProduction { get; set; }
        public int? EndYearOfProduction { get; set; }
        public int? StartMileage { get; set; }
        public int? EndMileage { get; set; }
        public string? EngineLayout { get; set; }
        public string? Location { get; set; }
        public string[]? Options { get; set; }
        public decimal? StartPrice { get; set; }
        public decimal? EndPrice { get; set; }
    }
}
