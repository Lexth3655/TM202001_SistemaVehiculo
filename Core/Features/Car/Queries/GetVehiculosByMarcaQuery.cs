using Core.Interfaces.Repository;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Car.Queries
{
    public sealed class GetVehiculosByMarcaQuery : IRequest<List<Vehiculo>>
    {
        public int MarcaId { get; set; }
    }

    public sealed class GetVehiculosByMarcaQueryHandler : IRequestHandler<GetVehiculosByMarcaQuery, List<Vehiculo>>
    {
        private readonly IRepository<Vehiculo> _repository;
        public GetVehiculosByMarcaQueryHandler(IRepository<Vehiculo> repository)
        {
            _repository = repository;
        }
        public async Task<List<Vehiculo>> Handle(GetVehiculosByMarcaQuery request, CancellationToken cancellationToken)
        {
            var vehiculos = await _repository.GetAllAsync(cancellationToken);
            return vehiculos.Where(v => v.MarcaId == request.MarcaId).ToList();
        }
    }
}
