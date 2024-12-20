using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Entities;


namespace ShopManagement.Infrastructures.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=DESKTOP-61NFUIU\\SQLEXPRESS;Initial Catalog=shoopPage;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        //    }
        //}
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
