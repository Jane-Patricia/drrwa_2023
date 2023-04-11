using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class BooksService
{
    private readonly IMongoCollection<JadwalGuru> _booksCollection;

    public BooksService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _booksCollection = mongoDatabase.GetCollection<JadwalGuru>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<JadwalGuru>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();

    public async Task<JadwalGuru?> GetAsync(string id) =>
        await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(JadwalGuru newJadwalGuru) =>
        await _booksCollection.InsertOneAsync(newJadwalGuru);

    public async Task UpdateAsync(string id, JadwalGuru updatedJadwalGuru) =>
        await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedJadwalGuru);

    public async Task RemoveAsync(string id) =>
        await _booksCollection.DeleteOneAsync(x => x.Id == id);
}