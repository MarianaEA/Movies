using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Dtos.Category
{
    public class MovieCreateUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [MaxLength(10)]
        public string Clasification { get; set; }

        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
