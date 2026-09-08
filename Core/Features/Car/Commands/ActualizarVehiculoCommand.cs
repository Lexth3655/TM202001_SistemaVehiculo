using Core.Interfaces.Repository;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Car.Commands
{
    public class ActualizarVehiculoCommand: IRequest<bool>
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string CantidadPuertas { get; set; }
        public int MarcaId { get; set; }
    }

    public class ActualizarVehiculoCommandHandler : IRequestHandler<ActualizarVehiculoCommand, bool>
    {
        private readonly IRepository<Vehiculo> _repository;
        public ActualizarVehiculoCommandHandler(IRepository<Vehiculo> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(ActualizarVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculo = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (vehiculo == null)
                throw new InvalidOperationException("Vehículo no encontrado");

            vehiculo.Modelo = request.Modelo;
            vehiculo.Anio = request.Anio;
            vehiculo.CantidadPuertas = request.CantidadPuertas;
            vehiculo.MarcaId = request.MarcaId;

            return await _repository.UpdateAsync(vehiculo, cancellationToken);
        }
    }
}
