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
    public sealed class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("Vehiculo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Modelo)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Anio)
                .IsRequired();
            builder.Property(x => x.CantidadPuertas)
                .IsRequired();
            
            // Relación con Marca (Muchos a Uno) - ya configurada desde Marca, pero podemos definir la FK aquí
            builder.HasOne(x => x.Marca)
                .WithMany(x => x.Vehiculos)
                .HasForeignKey(x => x.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Venta (Uno a Uno)
            builder.HasOne(x => x.Venta)
                .WithOne(x => x.Vehiculo)
                .HasForeignKey<Venta>(x => x.VehiculoId)
                .OnDelete(DeleteBehavior.SetNull); // Si se borra venta, los vehículos quedan sin venta
        }
    }
}
