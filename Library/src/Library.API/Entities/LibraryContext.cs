using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Library.API.Entities
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
           : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }

    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var sqlPath = "Server=(localdb)\\mssqllocaldb;Database=LibraryDB;Trusted_Connection=True;";

            var builder = new DbContextOptionsBuilder<LibraryContext>();
            builder.UseSqlServer(sqlPath,
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(LibraryContext).GetTypeInfo().Assembly.GetName().Name));

            return new LibraryContext(builder.Options);
        }
    }
}
