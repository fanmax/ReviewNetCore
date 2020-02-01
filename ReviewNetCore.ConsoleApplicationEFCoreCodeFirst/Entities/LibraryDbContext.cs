using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ReviewNetCore.ConsoleApplicationEFCoreCodeFirst.Entities
{
    public partial class LibraryDbContext : DbContext
    {
        private string _connectionString;
        private IConfiguration _configuration;
        public LibraryDbContext()
        {
            
        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>();

            _configuration = builder.Build();

            _connectionString = _configuration.GetConnectionString("DefaultConnection");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString, x => x.ServerVersion("8.0.18-mysql"));
            }
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = 1,
                    Name = "Rodrigo"
                },
                new Author()
                {
                    Id = 2,
                    Name = "Max"
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = 1,
                    Name = "Asp.Net Core Review",
                    Description = "Review",
                    AuthorId = 1
                },
                new Book()
                {
                    Id = 2,
                    Name = "Angular 8",
                    Description = "SPA",
                    AuthorId = 2
                }
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("Book_FK_Author_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AuthorId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("Book_FK_Author");
            });


            Seed(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
