using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAPI.Models;
using MinhaAPI.Repositorio;

namespace MinhaAPI.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModels>
    {
        public void Configure(EntityTypeBuilder<TarefaModels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
