namespace Blazor.Shared.MongoSittingServices
{
    public interface IMoviesDatabaseSettings
    {
        string CollectionCartMovies { get; set; }
        string CollectionCarts { get; set; }
        string CollectionGenres { get; set; }
        string CollectionMovies { get; set; }
        string CollectionUsers { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}