using System.ComponentModel.DataAnnotations;

namespace API.J.Movies.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Clasification { get; set; }

        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
