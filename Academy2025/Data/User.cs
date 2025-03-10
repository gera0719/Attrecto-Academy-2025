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
        [StringLength(75)]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }

        [Required]
        public int Age {  get; set; }
        [Required]
        public string? Role { get; set; }

        public ICollection<Course> Courses { get; set; } = [];
    }
}