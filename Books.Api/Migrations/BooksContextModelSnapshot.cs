﻿// <auto-generated />
using System;
using Books.Api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Books.Api.Migrations
{
    [DbContext(typeof(BooksContext))]
    partial class BooksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Books.Api.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new { Id = new Guid("64f7bbe0-f115-42b5-900f-f404c71f3581"), FirstName = "George", LastName = "RR Martin" },
                        new { Id = new Guid("a8028035-fdf7-404f-8dff-f93fa2097ad4"), FirstName = "Stephen", LastName = "Fry" }
                    );
                });

            modelBuilder.Entity("Books.Api.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new { Id = new Guid("4e86093d-f86c-4e8b-8582-b9004480ff06"), AuthorId = new Guid("64f7bbe0-f115-42b5-900f-f404c71f3581"), Description = "Desc of Book1", Title = "Book1" },
                        new { Id = new Guid("88d83575-5ea3-45e1-8f96-c848133e3417"), AuthorId = new Guid("a8028035-fdf7-404f-8dff-f93fa2097ad4"), Description = "Desc of Book2", Title = "Book2" }
                    );
                });

            modelBuilder.Entity("Books.Api.Entities.Book", b =>
                {
                    b.HasOne("Books.Api.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
