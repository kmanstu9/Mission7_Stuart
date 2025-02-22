using Microsoft.EntityFrameworkCore;
using Mission6_Stuart.Models;

public class MovieCollectionContext : DbContext
{
    public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options)
    {
    }

    public DbSet<Collection> Collection { get; set; }
    public DbSet<Category> Category { get; set; }

    // Ensure the Collection model is mapped to the "Movies" table
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Collection>()
            .ToTable("Movies"); // Map to the Movies table in the database

        modelBuilder.Entity<Category>()
            .ToTable("Categories"); // Ensure Categories table is correctly mapped as well

        //base.OnModelCreating(modelBuilder);
    }
}
