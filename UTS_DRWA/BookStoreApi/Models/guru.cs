using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string NIP { get; set; } = null!;

    public string Nama { get; set; } = null!;

    public string Fakultas { get; set; } = null!;
}