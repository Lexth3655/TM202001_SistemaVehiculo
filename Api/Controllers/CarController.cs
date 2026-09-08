using Core.Interfaces.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class CarController(IRepository<Vehiculo> vehiculoRepository, IRepository<Marca> marcaRepository) : Controller
    {
        [HttpGet("GetVehiculosByMarca/{marcaId}")]
        public async Task<IActionResult> GetVehiculosByMarca(int marcaId, CancellationToken cancellationToken)
        {
            var vehiculos = await vehiculoRepository.GetAllAsync(cancellationToken);
            var vehiculosByMarca = vehiculos.Where(v => v.MarcaId == marcaId).ToList();
            return Ok(vehiculosByMarca);
        }

        [HttpPost("CrearVehiculo")]
        public async Task<IActionResult> CrearVehiculo(Vehiculo vehiculo)
        {
            await vehiculoRepository.AddAsync(vehiculo, CancellationToken.None);
            return Ok();
        }

        [HttpPut("ActualizarVehiculo/{id}")]
        public async Task<IActionResult> ActualizarVehiculo(int id, Vehiculo vehiculo)
        {
            vehiculo.Id = id;
            await vehiculoRepository.UpdateAsync(vehiculo, CancellationToken.None);
            return Ok();
        }

        [HttpDelete("EliminarVehiculo/{id}")]
        public async Task<IActionResult> EliminarVehiculo(int id)
        {
            await vehiculoRepository.DeleteAsync(id, CancellationToken.None);
            return Ok();
        }
    }
}
