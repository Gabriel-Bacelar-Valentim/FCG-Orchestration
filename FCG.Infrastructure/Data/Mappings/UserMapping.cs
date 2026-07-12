using FCG.Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCG.Infrastructure.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.OwnsOne(u => u.Email, emailBuilder =>
            {
                emailBuilder.Property(e => e.Address)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(150);

                emailBuilder.HasIndex(e => e.Address).IsUnique();
            });

            builder.OwnsOne(u => u.Password, passBuilder =>
            {
                passBuilder.Property(p => p.Value)
                    .HasColumnName("Password")
                    .IsRequired();
            });

            builder.Property(u => u.Role)
                .IsRequired();
        }
    }
}