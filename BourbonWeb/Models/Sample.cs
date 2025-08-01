using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BourbonWeb.Models
{
    public class Sample
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "名称")]
        public required string Name { get; set; }

        [Range(0, 10000)]
        [Display(Name = "価格")]
        public decimal Price { get; set; }

        [Display(Name = "説明")]
        public string? Description { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "数量")]
        public int? Quantity { get; set; }

        [Range(0.0, double.MaxValue)]
        [Display(Name = "重量")]
        public double? Weight { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "対象年月")]
        public DateOnly? TargetYM { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "支払日")]
        public DateOnly? PaymentDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "更新日時")]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "状態")]
        public bool? IsActive { get; set; }

        [NotMapped]
        public string IsActiveDisplay => IsActive == true ? "有効" : "無効";

        [StringLength(100)]
        [Display(Name = "文字1")]
        public string? Text1 { get; set; }

        [StringLength(100)]
        [Display(Name = "文字2")]
        public string? Text2 { get; set; }

        [StringLength(100)]
        [Display(Name = "文字3")]
        public string? Text3 { get; set; }

        [StringLength(100)]
        [Display(Name = "文字4")]
        public string? Text4 { get; set; }

        [StringLength(100)]
        [Display(Name = "文字5")]
        public string? Text5 { get; set; }
    }
}
