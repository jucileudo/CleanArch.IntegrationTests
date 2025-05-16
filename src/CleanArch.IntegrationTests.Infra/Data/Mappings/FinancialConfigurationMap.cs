using CleanArch.IntegrationTests.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.IntegrationTests.Infra.Data.Mappings
{
    public class FinancialConfigurationMap : IEntityTypeConfiguration<FinancialConfiguration>
    {
        public void Configure(EntityTypeBuilder<FinancialConfiguration> builder)
        {
            builder.ToTable("FinancialConfigurations");

            builder.HasKey(fc => fc.Id);

            builder.Property(fc => fc.BaseSalary)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(fc => fc.ContractType)
                   .IsRequired();

            builder.Property(fc => fc.RegistrationDate)
                   .HasColumnType("timestamp with time zone")
                   .IsRequired();

            builder.Property(fc => fc.UserId)
                   .IsRequired();

            builder.Property(fc => fc.ConfigurationVersion)
                   .IsRequired();
        }
    }
}
