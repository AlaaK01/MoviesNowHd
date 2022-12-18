using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Blazor.Shared.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;
        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

    }
}
