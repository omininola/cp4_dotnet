using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cp4.Models;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }
    
    [BsonElement("title")]
    public required string Title { get; set; }
    
    [BsonElement("published_year")]
    public required int PublishedYear { get; set; }
    
    [BsonElement("authors")]
    public required List<Author> Authors { get; set; }
}