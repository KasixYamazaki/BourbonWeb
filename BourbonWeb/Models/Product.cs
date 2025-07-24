using System.ComponentModel.DataAnnotations;

namespace BourbonWeb.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9]*$", ErrorMessage = "半角英数字のみを入力してください。")]
        public required string Name { get; set; }

        [Range(0, 10000)]
        public decimal Price { get; set; }

        public required string Description { get; set; }
    }
}
