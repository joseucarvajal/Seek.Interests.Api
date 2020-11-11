using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeekQ.Interests.Api.Domain.InterestAggregate;

namespace SeekQ.Interests.Api.Infrastructure.EntityConfigurations
{
    public class UserInterestsEntityConfiguration : IEntityTypeConfiguration<UserInterest>
    {
        public void Configure(EntityTypeBuilder<UserInterest> builder)
        {
            builder.ToTable("UserInterests");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.IdUser)
                .IsRequired(true);

            builder.Property(c => c.IdInterest)
                .IsRequired(true);

            builder.HasIndex(c => new { c.IdUser, c.IdInterest }).IsUnique();

            builder.Property(c => c.Visibility)
                .IsRequired(true);
        }
    }
}
