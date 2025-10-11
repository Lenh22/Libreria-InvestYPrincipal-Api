using Libreria_InvestYPrincipal_Api.Models;

namespace Libreria_InvestYPrincipal_Api.Data
{
    public static class SeedData //Datos de inicializacion (Como un Mockeo)
    {
        public static void Initialize(LibraryDbContext context)
        {
            if (context.Authors.Any() || context.Books.Any())
            {
                return; // Database has been seeded
            }

            var authors = new List<Author>
            {
                new Author
                {
                    Name = "Gabriel García Márquez",
                    BirthDate = new DateTime(1927, 3, 6),
                    Nationality = "Colombiana"
                },
                new Author
                {
                    Name = "Mario Vargas Llosa",
                    BirthDate = new DateTime(1936, 3, 28),
                    Nationality = "Peruana"
                },
                new Author
                {
                    Name = "Jorge Luis Borges",
                    BirthDate = new DateTime(1899, 8, 24),
                    Nationality = "Argentina"
                },
                new Author
                {
                    Name = "Isabel Allende",
                    BirthDate = new DateTime(1942, 8, 2),
                    Nationality = "Chilena"
                }
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Cien años de soledad",
                    Genre = "Fiction",
                    PublishDate = new DateTime(1967, 6, 5),
                    Pages = 471,
                    Publisher = "Editorial Sudamericana",
                    ISBN = "978-84-376-0494-7",
                    Price = 25.99m,
                    Language = "Spanish",
                    AuthorId = authors[0].Id
                },
                new Book
                {
                    Title = "El amor en los tiempos del cólera",
                    Genre = "Fiction",
                    PublishDate = new DateTime(1985, 1, 1),
                    Pages = 368,
                    Publisher = "Editorial Oveja Negra",
                    ISBN = "978-84-376-0495-4",
                    Price = 22.50m,
                    Language = "Spanish",
                    AuthorId = authors[0].Id
                },
                new Book
                {
                    Title = "La ciudad y los perros",
                    Genre = "Fiction",
                    PublishDate = new DateTime(1963, 1, 1),
                    Pages = 320,
                    Publisher = "Editorial Seix Barral",
                    ISBN = "978-84-322-0496-1",
                    Price = 20.99m,
                    Language = "Spanish",
                    AuthorId = authors[1].Id
                },
                new Book
                {
                    Title = "Ficciones",
                    Genre = "Fiction",
                    PublishDate = new DateTime(1944, 1, 1),
                    Pages = 200,
                    Publisher = "Editorial Sur",
                    ISBN = "978-84-376-0497-8",
                    Price = 18.75m,
                    Language = "Spanish",
                    AuthorId = authors[2].Id
                },
                new Book
                {
                    Title = "La casa de los espíritus",
                    Genre = "Fiction",
                    PublishDate = new DateTime(1982, 1, 1),
                    Pages = 432,
                    Publisher = "Editorial Plaza & Janés",
                    ISBN = "978-84-376-0498-5",
                    Price = 24.99m,
                    Language = "Spanish",
                    AuthorId = authors[3].Id
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
