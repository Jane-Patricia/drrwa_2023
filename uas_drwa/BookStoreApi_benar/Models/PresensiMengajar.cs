   
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UasDRWA.Models;

public class PresensiMengajar
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    
    public string? Id { get; set; }

    public decimal? NIP { get; set; } = null!;
    public string Tgl { get; set; } = null!;
    public string Kehadiran { get; set; } = null!;
    public string Kelas { get; set; } = null!;

}