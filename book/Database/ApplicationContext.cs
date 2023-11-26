using Microsoft.EntityFrameworkCore;

namespace book.Database
{

    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Name = "Tom", Age = 37 },
                    new User { Id = 2, Name = "Bob", Age = 41 },
                    new User { Id = 3, Name = "Sam", Age = 24 }
            );
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Fantastic", Slug = "Fantastic" }

            );
            modelBuilder.Entity<Product>().HasData(
                   new Product
                   {
                       Id = 1,
                       Name = "A Song of Ice and Fire",
                       Price = 100,
                       Slug = "IceandFire",
                       Categories = { },
                   },
                   new Product
                   {
                       Id = 2,
                       Name = "The Lord of the Rings",
                       Price = 200,
                       Slug = "LordoftheRings",
                       Categories = { }
                   },
                   new Product
                   {
                       Id = 3,
                       Name = "War and peace",
                       Price = 300,
                       Slug = "Warandpeace",
                       Categories = { }
                   }
                );
        }
    }
}
