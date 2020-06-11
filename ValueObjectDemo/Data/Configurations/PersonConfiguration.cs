using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValueObjectDemo.Types;

namespace ValueObjectDemo.Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.OwnsOne(entity => entity.Address, address =>
            {
                address.OwnsOne(item => item.ZipCode, zipCode => 
                {
                    zipCode.Property(item => item.Code)
                           .HasColumnName("ZipCode")
                           .HasDefaultValue("");

                    zipCode.Property(item => item.PlusFour)
                           .HasColumnName("PlusFour")
                           .HasDefaultValue("");
                });

                address.Property(p => p.StreetAddress)
                       .HasMaxLength(600)
                       .HasColumnName("StreetAddress")
                       .HasDefaultValue("");
                address.Property(p => p.City)
                       .HasMaxLength(150)
                       .HasColumnName("City")
                       .HasDefaultValue("");
                address.Property(p => p.State)
                       .HasMaxLength(60)
                       .HasColumnName("State")
                       .HasDefaultValue("");

                address.ToTable("Addresses");
            });

            builder.OwnsOne(entity => entity.Status, status =>
            {
                status.Property("Value")
                      .HasMaxLength(600)
                      .HasColumnName("Status")
                      .HasDefaultValue("Available");
            });
        }
    }
}
