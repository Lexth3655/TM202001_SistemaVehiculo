using Core.Interfaces.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class SaleController(IRepository<Venta> ventaRepository, IRepository<Vehiculo> vehiculoRepository) : Controller
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenta(int id, CancellationToken cancellationToken)
        {
            var venta = await ventaRepository.GetByIdAsync(id, cancellationToken);
            if (venta == null)
            {
                return NotFound();
            }
            return Ok(venta);
        }

        [HttpPost]
        public async Task<IActionResult> RealizarVenta([FromBody] CreateVentaRequest request, CancellationToken cancellationToken)
        {
            // 1. Validación básica del request
            if (request == null)
                return BadRequest("Datos inválidos.");

            if (request.Cantidad <= 0)
                return BadRequest("La cantidad debe ser mayor a cero.");

            if (request.TotalVenta <= 0)
                return BadRequest("El total de la venta debe ser mayor a cero.");

            // 2. Validar que el vehículo exista
            var vehiculo = await vehiculoRepository.GetByIdAsync(request.VehiculoId, cancellationToken);
            if (vehiculo == null)
                return NotFound($"El vehículo con ID {request.VehiculoId} no existe.");

            // 3. Crear la entidad Venta (el Id se genera automáticamente)
            var venta = new Venta
            {
                VehiculoId = request.VehiculoId,
                Cantidad = request.Cantidad,
                TotalVenta = request.TotalVenta
            };

            // 4. Guardar en la base de datos (AddAsync ya hace SaveChanges)
            await ventaRepository.AddAsync(venta, cancellationToken);

            // 5. Devolver respuesta con el Id generado
            return CreatedAtAction(nameof(GetVenta), new { id = venta.Id }, venta);
        }

        // DTO de solicitud (anidado dentro del mismo archivo)
        public record CreateVentaRequest
        {
            public int VehiculoId { get; init; }
            public int Cantidad { get; init; }
            public decimal TotalVenta { get; init; }
        }
    }
}
