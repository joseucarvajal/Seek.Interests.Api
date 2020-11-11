using Microsoft.EntityFrameworkCore;
using SeekQ.Interests.Api.Domain.InterestAggregate;
using SeekQ.Interests.Api.Infrastructure.EntityConfigurations;

namespace SeekQ.Interests.Api.Infrastructure
{
    public class InterestsDbContext : DbContext
    {
        public InterestsDbContext(DbContextOptions<InterestsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Interest> Interests { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<BlackList> BlackLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlackListEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InterestEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserInterestsEntityConfiguration());
        }
    }
}
