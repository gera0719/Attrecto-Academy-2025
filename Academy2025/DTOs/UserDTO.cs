using System.ComponentModel.DataAnnotations;

namespace Academy2025.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
        

        [Required]
        public int Age { get; set; }
        [Required]
        public string? Role { get; set; }
    }
}
