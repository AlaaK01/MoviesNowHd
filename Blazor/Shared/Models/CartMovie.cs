using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Blazor.Shared.Models
{
    public class CartMovie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } 
        [BsonElement("cartId")]
        public string CartId { get; set; } = string.Empty;
        [BsonElement("movieId")]
        public string MovieId { get; set; } = string.Empty;
        [BsonElement("quantity")]
        public int Quantity { get; set; } = 0;
    }
}
