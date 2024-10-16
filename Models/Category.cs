using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAppMVC.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(100), MinLength(3)]
        [Required]
        public required string Name { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        [Display(Name = "Created Date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Set default value here

        public ICollection<Product>? Products { get; set; }
    }
}