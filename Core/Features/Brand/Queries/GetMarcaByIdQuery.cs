using Core.Interfaces.Repository;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Brand.Queries
{
    public sealed class GetMarcaByIdQuery : IRequest<Marca>
    {
        public int Id { get; set; }
    }

    public sealed class GetMarcaByIdQueryHandler : IRequestHandler<GetMarcaByIdQuery, Marca>
    {
        private readonly IRepository<Marca> _repository;
        public GetMarcaByIdQueryHandler(IRepository<Marca> repository)
        {
            _repository = repository;
        }
        public async Task<Marca> Handle(GetMarcaByIdQuery request, CancellationToken cancellationToken)
        {
            var marca = await _repository.GetByIdAsync(request.Id, cancellationToken);
            return marca;
        }
    }
}
