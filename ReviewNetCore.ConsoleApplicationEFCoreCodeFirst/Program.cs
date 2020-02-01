using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReviewNetCore.ConsoleApplicationEFCoreCodeFirst.Entities;

namespace ReviewNetCore.ConsoleApplicationEFCoreCodeFirst
{
    class Program
    {
        
        private LibraryDbContext _dbContext;
        static void Main(string[] args) => new Program().Test();

        public void Test()
        {
            _dbContext = new LibraryDbContext();

            var booksWithAuthors = _dbContext.Books.Include(b => b.Author).ToList();

            foreach (var book in booksWithAuthors)
            {
                Console.WriteLine($"Id: {book.Id}; Name: {book.Name}; Descripton: {book.Description};");
                Console.WriteLine($"Author: {book.Author.Name}");
            }

            Console.ReadKey();
        }
    }
}
