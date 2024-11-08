using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Employee
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
    }
}
