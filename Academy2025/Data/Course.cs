using System.ComponentModel.DataAnnotations;

namespace Academy2025.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        [Required]
        [StringLength(300)]
        public string? Description { get; set; }
        [Required]
        public string? Url { get; set; }
        public ICollection<User> Users { get; set; } = [];
    }
}
