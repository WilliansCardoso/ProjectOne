using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data.Map;
using MinhaAPI.Models;

namespace MinhaAPI.Data
{
    public class SistemaDeTarefasDbContext : DbContext
    {
        public SistemaDeTarefasDbContext(DbContextOptions<SistemaDeTarefasDbContext> options  ) : base(options)
        {            
        }

        public DbSet<UsuarioModels> Usuarios { get; set; }
        public DbSet<TarefaModels> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
