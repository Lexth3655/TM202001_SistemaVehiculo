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
    public class EliminarVehiculoCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class EliminarVehiculoCommandHandler : IRequestHandler<EliminarVehiculoCommand, bool>
    {
        private readonly IRepository<Vehiculo> _repository;
        public EliminarVehiculoCommandHandler(IRepository<Vehiculo> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(EliminarVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculo = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (vehiculo == null)
            {
                return false;
            }
            await _repository.DeleteAsync(vehiculo.Id, cancellationToken);
            return true;
        }
    }
}
