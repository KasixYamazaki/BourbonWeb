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

        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }

        [Range(0.0, double.MaxValue)]
        public double? Weight { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? TargetYM { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? PaymentDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? UpdatedAt { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(100)]
        public string? Text1 { get; set; }

        [StringLength(100)]
        public string? Text2 { get; set; }

        [StringLength(100)]
        public string? Text3 { get; set; }

        [StringLength(100)]
        public string? Text4 { get; set; }

        [StringLength(100)]
        public string? Text5 { get; set; }
    }
}
