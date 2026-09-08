using Core.Interfaces.Repository;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Sale.Commads
{
    public class CrearVentaCommand: IRequest<Venta>
    {
        public int VehiculoId { get; set; }
        public int Cantidad { get; set; }
        public decimal TotalVenta { get; set; } = 0;
    }

    public class CrearVentaCommandHandler : IRequestHandler<CrearVentaCommand, Venta>
    {
        private readonly IRepository<Venta> _ventaRepository;
        private readonly IRepository<Vehiculo> _vehiculoRepository;
        public CrearVentaCommandHandler(IRepository<Venta> ventaRepository, IRepository<Vehiculo> vehiculoRepository)
        {
            _ventaRepository = ventaRepository;
            _vehiculoRepository = vehiculoRepository;
        }
        public async Task<Venta> Handle(CrearVentaCommand request, CancellationToken cancellationToken)
        {
            // 1. Validar que el vehículo existe (lógica de negocio)
            var vehiculo = await _vehiculoRepository.GetByIdAsync(request.VehiculoId, cancellationToken);
            if (vehiculo == null)
            {
                throw new System.Exception($"El vehículo con ID {request.VehiculoId} no existe.");
            }

            // 2. Crear la entidad Venta (sin asignar Id, la BD lo genera)
            var venta = new Venta
            {
                VehiculoId = request.VehiculoId,
                Cantidad = request.Cantidad,
                TotalVenta = request.TotalVenta
            };

            // 3. Guardar usando el repositorio (AddAsync ya hace SaveChanges internamente)
            await _ventaRepository.AddAsync(venta, cancellationToken);

            // 4. Devolver el DTO
            return venta;
        }
    }

}
