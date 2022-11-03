using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Caso eu esqueça de setar alguma coisa no Mapping, esse código vai garantir
            // que um campo string não seja criado como nvarchar
            // (que aloca 1 espaço de memória pro simbolo e 1 pro valor, pra alfabeto chinês por exemplo)
            // e que tenha no máximo 1000 caracteres
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                if (property.GetMaxLength() == null)
                {
                    property.SetMaxLength(1000);
                }

                if (string.IsNullOrEmpty(property.GetColumnType()))
                {
                    property.SetColumnType("varchar");
                }
            }

            // Aplica os Mappings
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            // Desativa o cascade delete
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
