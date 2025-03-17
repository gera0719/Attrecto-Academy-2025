using System.ComponentModel.DataAnnotations;
using Academy2025.Data;

namespace Academy2025.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        [Required]
        [StringLength(50)]
        public string? Author { get; set; }
        [Required]
        [StringLength(300)]
        public string? Description { get; set; }
        [Required]
        public string? Url { get; set; }
    }
}
