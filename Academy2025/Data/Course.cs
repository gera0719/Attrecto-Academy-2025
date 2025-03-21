﻿using System.ComponentModel.DataAnnotations;

namespace Academy2025.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public ICollection<User> Users { get; set; } = [];
    }
}
