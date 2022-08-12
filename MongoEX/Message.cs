using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Message
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ID { get; set;}
    public string Name { get; set; }
    public string Text { get; set; }
    public DateTime Moment { get; set; }
}