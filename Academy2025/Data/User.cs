using System.ComponentModel.DataAnnotations;

namespace Academy2025.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Required]
        public string? Password { get; set; }

        [Required]
        public int age {  get; set; }

        public ICollection<Course> courses { get; set; } = [];
    }
}