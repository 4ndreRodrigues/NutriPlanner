using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutriPlanner.Models;

namespace NutriPlanner.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<DietFood> DietFoods { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserSelection> UserSelections { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DietFood>()
                .HasKey(df => new { df.DietId, df.FoodId });

            modelBuilder.Entity<DietFood>()
                .HasOne(df => df.Diet)
                .WithMany(d => d.DietFoods)
                .HasForeignKey(df => df.DietId);

            modelBuilder.Entity<DietFood>()
                .HasOne(df => df.Food)
                .WithMany(f => f.DietFoods)
                .HasForeignKey(df => df.FoodId);
        }
    }
}
