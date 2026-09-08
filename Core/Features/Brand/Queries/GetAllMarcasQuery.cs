using Core.Interfaces.Repository;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Brand.Queries
{
    public class GetAllMarcasQuery : IRequest<List<Marca>> { }

    public class GetAllMarcasHandler : IRequestHandler<GetAllMarcasQuery, List<Marca>>
    {
        private readonly IRepository<Marca> _repository;

        public GetAllMarcasHandler(IRepository<Marca> repository) => _repository = repository;

        public async Task<List<Marca>> Handle(GetAllMarcasQuery request, CancellationToken cancellationToken)
        {
            var marcas = await _repository.GetAllAsync(cancellationToken);
            return marcas.Select(m => new Marca { Id = m.Id, Nombre = m.Nombre }).ToList();
        }
    }
}
