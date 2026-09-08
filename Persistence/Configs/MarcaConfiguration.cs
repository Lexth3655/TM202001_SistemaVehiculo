using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configs
{
    public sealed class MarcaConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.ToTable("Marca", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            // Configurar la relación uno a muchos con Vehiculo
            builder.HasMany(x => x.Vehiculos)
                .WithOne(x => x.Marca)
                .HasForeignKey(x => x.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
