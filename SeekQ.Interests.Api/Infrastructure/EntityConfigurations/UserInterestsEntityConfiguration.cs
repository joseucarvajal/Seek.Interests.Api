using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeekQ.Interests.Api.Domain.InterestAggregate;
using System;

namespace SeekQ.Interests.Api.Infrastructure.EntityConfigurations
{
    public class UserInterestsEntityConfiguration : IEntityTypeConfiguration<UserInterest>
    {
        public void Configure(EntityTypeBuilder<UserInterest> builder)
        {
            builder.ToTable("UserInterests");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => new { u.IdUser, u.IdInterest }).IsUnique();

            builder.Property(u => u.Visibility)
                .IsRequired(true);

            builder.Property<Guid>("IdInterest")
                           .UsePropertyAccessMode(PropertyAccessMode.Field)
                           .HasColumnName("IdInterest")
                           .IsRequired(true);

            builder.HasOne(u => u.Interests)
                .WithMany()
                .HasForeignKey("IdInterest");
        }
    }
}
