


namespace Blazor.Shared.Dto
{
    public class MovieDto
    {
        public string Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
        public double Rate { get; set; } = 0;
        public double Price { get; set; } = 0;
        public string Summary { get; set; } = string.Empty;
        public List<string> Actors { get; set; } = new List<string>();
        public string ImageUrl { get; set; } = string.Empty;
    }
}
