using Books.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api.Contexts
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(

                new Book()
                {
                    Id = Guid.Parse("4E86093D-F86C-4E8B-8582-B9004480FF06"),
                    AuthorId = Guid.Parse("64F7BBE0-F115-42B5-900F-F404C71F3581"),
                    Title = "Book1",
                    Description = "Desc of Book1"

                },

                new Book()
                {
                    Id = Guid.Parse("88D83575-5EA3-45E1-8F96-C848133E3417"),
                    AuthorId = Guid.Parse("A8028035-FDF7-404F-8DFF-F93FA2097AD4"),
                    Title = "Book2",
                    Description = "Desc of Book2"

                }

                );

            modelBuilder.Entity<Author>().HasData(

              new Author()
              {
                  Id = Guid.Parse("64F7BBE0-F115-42B5-900F-F404C71F3581"),
                  FirstName = "George",
                  LastName = "RR Martin"

              },

              new Author()
              {
                  Id = Guid.Parse("A8028035-FDF7-404F-8DFF-F93FA2097AD4"),
                  FirstName = "Stephen",
                  LastName = "Fry"

              }

              );
        }
    }
}
