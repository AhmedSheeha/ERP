using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class Item
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Category")]
        [ForeignKey(nameof(Category))]
        public int CategoryId {  get; set; }
        [NotMapped]
        public IFormFile ClientFile { get; set; }
        public Category? Category { get; set; }


    }
}
