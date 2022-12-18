using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;





namespace Blazor.Shared.Models
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("userId")]
        public string UserId { get; set; }
    }
}
