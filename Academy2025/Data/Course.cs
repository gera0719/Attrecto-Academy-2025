using System.ComponentModel.DataAnnotations;

namespace Academy2025.Data
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(300)]
        public string? Description { get; set; }
    }
}
