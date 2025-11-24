namespace API.J.Movies.DAL.Dtos.Category
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Clasification { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
