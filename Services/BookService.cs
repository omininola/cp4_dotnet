using cp4.Models;
using MongoDB.Driver;

namespace cp4.Services;

public class BookService
{
    private readonly IMongoCollection<Book> _books;

    public BookService(IMongoCollection<Book> books)
    {
        _books = books;
    }

    // Create
    public async Task<Book> InsertBook(Book book)
    {
        await _books.InsertOneAsync(book);
        return book;
    }
    
    // Find All
    public async Task<List<Book>> GetBooks() => await _books.Find(book => true).ToListAsync();
    
    // Find By ID
    public async Task<Book?> GetBook(string id) => await _books.Find(book => book.Id == id).FirstOrDefaultAsync();
    
    // Update
    public async Task<Book?> UpdateBook(string id, Book book)
    {
        await _books.ReplaceOneAsync(b => b.Id == id, book);
        return book;
    }
    
    // Delete
    public async Task<bool> DeleteBook(string id)
    {
        var result = await _books.DeleteOneAsync(b => b.Id == id);
        return result.DeletedCount > 0;
    }
}