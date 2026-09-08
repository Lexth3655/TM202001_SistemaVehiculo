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
    public sealed class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("Venta");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalVenta)
                .IsRequired()
                .HasPrecision(18, 2);
            builder.Property(x => x.Cantidad)
                .IsRequired();

            // Si quieres asegurar que VehiculoId sea único (para relación 1 a 1)
            builder.HasIndex(x => x.VehiculoId)
                .IsUnique()
                .HasDatabaseName("IX_Venta_VehiculoId_Unique");
        }
    }
}
