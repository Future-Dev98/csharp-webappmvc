using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(100), MinLength(3)]
        [Required]
        public required string Title { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Created Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
