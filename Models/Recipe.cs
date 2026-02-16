using System.ComponentModel.DataAnnotations;

namespace ProCookBook.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Ingredients { get; set; } = string.Empty;

        [Required]
        public string Instructions { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Range(1, 300)]
        public int CookingTime { get; set; }
    }
}
