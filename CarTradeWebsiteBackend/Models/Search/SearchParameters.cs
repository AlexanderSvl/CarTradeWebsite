using System.ComponentModel.DataAnnotations;

namespace CarTradeWebsite.Models.Search
{
    public class SearchParameters
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CarMake { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        public string TransmissionType { get; set; }

        [Required]
        public string FuelType { get; set; }

        [Required]
        public string EngineDisplacement { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int YearOfProduction { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public string EngineLayout { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public IEnumerable<OptionModel> Options { get; set; }

        [Required]
        public IEnumerable<ImageModel> CarImages { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
