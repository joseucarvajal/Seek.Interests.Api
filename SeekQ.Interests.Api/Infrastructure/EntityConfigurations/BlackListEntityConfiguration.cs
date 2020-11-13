using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeekQ.Interests.Api.Domain.InterestAggregate;

namespace SeekQ.Interests.Api.Infrastructure.EntityConfigurations
{
    public class BlackListEntityConfiguration : IEntityTypeConfiguration<BlackList>
    {
        public void Configure(EntityTypeBuilder<BlackList> builder)
        {
            builder.ToTable("BlackLists");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50);

            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}
