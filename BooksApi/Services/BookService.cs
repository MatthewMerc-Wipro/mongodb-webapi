using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BooksApi.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookstoreDb"));
            var database = client.GetDatabase("BookstoreDb");
            _books = database.GetCollection<Book>("Books");
        }

        public async Task<IList<Book>> Get()
        {
            var books = await _books.Find(book => true).ToListAsync();
            return  books;
        }

        public async Task<Book> Get(string id)
        {
          var book = await _books.Find(b => b.Id == id).SingleAsync();
          return book;
        }

        public async Task<Book> Create(Book book)
        {
            await _books.InsertOneAsync(book);
            return book;
        }

        public async void Update(string id, Book bookIn)
        {
            await _books.ReplaceOneAsync(book => book.Id == id, bookIn);
        }

        public async void Remove(Book bookIn)
        {
            await _books.DeleteOneAsync(book => book.Id == bookIn.Id);
        }

        public async void Remove(string id)
        {
            await _books.DeleteOneAsync(book => book.Id == id);
        }
    }
}