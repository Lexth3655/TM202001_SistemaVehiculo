using Core.Interfaces.Repository;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class BrandController(IRepository<Marca> marcaRepository) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var marcas = await marcaRepository.GetAllAsync(CancellationToken.None);
            return Ok(marcas);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Marca marca)
        {
            await marcaRepository.AddAsync(marca, CancellationToken.None);
            return Ok();
        }
                

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Marca marca)
        {
            // Asegurar que el id recibido se aplique a la entidad antes de actualizar.
            marca.Id = id;
            await marcaRepository.UpdateAsync(marca, CancellationToken.None);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var marca = await marcaRepository.GetByIdAsync(id, CancellationToken.None);
            if (marca == null)
            {
                return NotFound();
            }

            await marcaRepository.DeleteAsync(id, CancellationToken.None);
            return Ok();
        }
    }
}
