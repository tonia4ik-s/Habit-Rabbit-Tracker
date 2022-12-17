using System.Reflection;
using Core.Entities;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {}
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<DailyTask> DailyTasks { get; set; }
        public DbSet<DailySubtask> DailySubtasks { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ChallengeType> ChallengeTypes { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
        public DbSet<Visibility> Visibilities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedData();
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UserConfiguration))!);
            base.OnModelCreating(builder);
        }
    }
}
