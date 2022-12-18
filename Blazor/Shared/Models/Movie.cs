using MongoDB.Bson.Serialization.Attributes;


namespace Blazor.Shared.Models
{
    [BsonIgnoreExtraElements]
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;
        [BsonElement("genre")]
        public string Genre { get; set; } = string.Empty;
        [BsonElement("year")]
        public int Year { get; set; } = 0;
        [BsonElement("rate")]
        public double Rate { get; set; } = 0;
        [BsonElement("Price")]
        public double Price { get; set; }
        
        [BsonElement("summary")]
        public string Summary { get; set; } =string.Empty;
        [BsonElement("actors")]
        public List<string> Actors { get; set; } = new List<string>();
        [BsonElement("imageUrl")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
