using System.ComponentModel.DataAnnotations;

namespace BourbonWeb.Models
{
    public class Sample
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Required]
        public required string Description { get; set; }
    }
}
