using Core.Interfaces.Repository;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Car.Commands
{
    public class CrearVehiculoCommand: IRequest<Vehiculo>
    {
        public string Modelo { get; set; }
        public int Anio { get; set; } 
        public string CantidadPuertas { get; set; }
        public int MarcaId { get; set; }
    }

    public class CrearVehiculoCommandHandler : IRequestHandler<CrearVehiculoCommand, Vehiculo>
    {
        private readonly IRepository<Vehiculo> _repository;
        public CrearVehiculoCommandHandler(IRepository<Vehiculo> repository)
        {
            _repository = repository;
        }
        public async Task<Vehiculo> Handle(CrearVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculo = new Vehiculo
            {
                Modelo = request.Modelo,
                Anio = request.Anio,
                CantidadPuertas = request.CantidadPuertas,
                MarcaId = request.MarcaId
            };
            await _repository.AddAsync(vehiculo, cancellationToken);
            return vehiculo;
        }
    }
}
