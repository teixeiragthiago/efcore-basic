using System.Reflection;
using EFCore.Data.Configurations;
using EFCore.Domain;

namespace EFCore.Data;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=CursoEFCore;User Id=SA;Password=Jqmg@dubZ0101;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new ClienteConfigurations());
        // modelBuilder.ApplyConfiguration(new PedidoConfigurations());
        // modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());
        // modelBuilder.ApplyConfiguration(new ProdutoConfigurations());

        /*
         Criar Script da migration
            dotnet ef migrations script -o ./Migrations/Scripts/PrimeiraMigracao.sql
            
         Criar Script idempotente da migration
            dotnet ef migrations script -o ./Migrations/Scripts/PrimeiraMigracaoIdempotente.sql -i            
            
         */
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}