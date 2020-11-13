using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeekQ.Interests.Api.Domain.InterestAggregate;

namespace SeekQ.Interests.Api.Infrastructure.EntityConfigurations
{
    public class InterestEntityConfiguration : IEntityTypeConfiguration<Interest>
    {
        public void Configure(EntityTypeBuilder<Interest> builder)
        {
            builder.ToTable("Interests");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50);

            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.PeopleCount)
                .IsRequired(true);

            builder.Property(c => c.Visibility)
                .IsRequired(true);
        }
    }
}
