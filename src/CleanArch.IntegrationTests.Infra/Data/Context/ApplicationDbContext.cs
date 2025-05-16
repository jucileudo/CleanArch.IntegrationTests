using CleanArch.IntegrationTests.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArch.IntegrationTests.Infra.Data.Context
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<FinancialConfiguration> FinancialConfigurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var tiposEntidade = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t =>
                    t.IsClass
                 && !t.IsAbstract
                 && t.Namespace != null
                 && t.Namespace.StartsWith("CleanArch.IntegrationTests.Domain.Entities")
                );

            foreach (var tipo in tiposEntidade)
            {
                modelBuilder.Entity(tipo);
            }

            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                                  .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            foreach (var fk in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }
    }
}
