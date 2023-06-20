   
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UasDRWA.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    
    public string? Id { get; set; }
    
    [BsonElement("Nama")]
    [JsonPropertyName("Nama")]
    public string Nama { get; set; } = null!;
    public string Kelas { get; set; } = null!;
    public decimal? NIP { get; set; } = null!;
}