using MongoDB.Bson.Serialization.Attributes;



namespace Blazor.Shared.Models
{
    public class Genre
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string genreName { get; set; } = string.Empty;
    }
}
