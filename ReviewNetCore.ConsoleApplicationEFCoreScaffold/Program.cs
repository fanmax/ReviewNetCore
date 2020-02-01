using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReviewNetCore.ConsoleApplicationEFCoreScaffold.Entities;

namespace ReviewNetCore.ConsoleApplicationEFCoreScaffold
{
    class Program
    {
        private IConfigurationRoot _configuration;
        private LibraryDbContext _dbContext;
        static void Main(string[] args) => new Program().Test();

        public void Test()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>();

            _configuration = builder.Build();

            _dbContext = new LibraryDbContext(_configuration.GetConnectionString("DefaultConnection"));

            var books = _dbContext.Books.Include(b => b.Author).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"Id: {book.Id}; Name: {book.Name}; Descripton: {book.Description};");
                Console.WriteLine($"Author: {book.Author.Name}");
            }

            Console.ReadKey();
        }
    }
}
