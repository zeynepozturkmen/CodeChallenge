using CodeChallenge.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodeChallenge.DbContexts
{
    public class CodeChallengeDbContext : DbContext
    {

        public CodeChallengeDbContext(DbContextOptions<CodeChallengeDbContext> options) : base(options)
        {

        }

        public DbSet<Groups> Groups { get; set; }
        public DbSet<Teams> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
