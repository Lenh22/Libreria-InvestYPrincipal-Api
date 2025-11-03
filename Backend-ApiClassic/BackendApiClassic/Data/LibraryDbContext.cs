using BackendApiClassic.Models;
using System.Data.Entity;

namespace BackendApiClassic.Data
{
    public class LibraryDbContext : DbContext
    {
        // Nombre del connection string en Web.config
        public LibraryDbContext() : base("LibraryDbConnection")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuración de la relación uno a muchos entre Author y Book
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithRequired(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
