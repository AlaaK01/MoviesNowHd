namespace Blazor.Shared.MongoSittingServices
{
    public class MoviesDatabaseSettings : IMoviesDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionMovies { get; set; }
        public string CollectionCarts { get; set; }
        public string CollectionCartMovies { get; set; }
        public string CollectionUsers { get; set; }
        public string CollectionGenres { get; set; }
    }
}
