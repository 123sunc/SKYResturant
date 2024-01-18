using System.ComponentModel.DataAnnotations.Schema;

namespace SKYResturant.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string Ingredients { get; set; }
        public string Category { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
