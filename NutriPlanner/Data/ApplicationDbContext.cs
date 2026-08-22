using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutriPlanner.Models;

namespace NutriPlanner.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<DietFood> DietFoods { get; set; }
        public DbSet<UserFood> UserFoods { get; set; }
        public DbSet<NutritionInfo> NutritionInfos { get; set; }
        public DbSet<HealthCondition> HealthConditions { get; set; }
        public DbSet<HealthConditionFood> HealthConditionFoods { get; set; }
        public DbSet<UserHealthCondition> UserHealthConditions { get; set; }


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


            modelBuilder.Entity<NutritionInfo>()
                .HasKey(n => n.FoodId);

            modelBuilder.Entity<NutritionInfo>()
                .HasOne(n => n.Food)
                .WithOne(f => f.NutritionInfo)
                .HasForeignKey<NutritionInfo>(n => n.FoodId);


            modelBuilder.Entity<UserFood>()
                .HasIndex(us => new { us.UserId, us.FoodId })
                .IsUnique();

            modelBuilder.Entity<ApplicationUser>()
                .HasOne<Diet>()
                .WithMany()
                .HasForeignKey(u => u.DietId);


            modelBuilder.Entity<HealthConditionFood>()
                .HasKey(hcf => new { hcf.HealthConditionId, hcf.FoodId });

            modelBuilder.Entity<HealthConditionFood>()
                .HasOne(hcf => hcf.HealthCondition)
                .WithMany(hc => hc.HealthConditionFoods)
                .HasForeignKey(hcf => hcf.HealthConditionId);

            modelBuilder.Entity<HealthConditionFood>()
                .HasOne(hcf => hcf.Food)
                .WithMany(f => f.HealthConditionFoods)
                .HasForeignKey(hcf => hcf.FoodId);


            modelBuilder.Entity<UserHealthCondition>()
                .HasIndex(uhc => new { uhc.UserId, uhc.HealthConditionId })
                .IsUnique();
                
        }
    }
}
