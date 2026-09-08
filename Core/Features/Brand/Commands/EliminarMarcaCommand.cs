using Core.Interfaces.Repository;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Features.Brand.Commands
{
    public class EliminarMarcaCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class EliminarMarcaCommandHandler : IRequestHandler<EliminarMarcaCommand, bool>
    {
        private readonly IRepository<Marca> _repository;
        public EliminarMarcaCommandHandler(IRepository<Marca> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(EliminarMarcaCommand request, CancellationToken cancellationToken)
        {
            var marca = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (marca == null)
            {
                return false;
            }
            await _repository.DeleteAsync(marca.Id, cancellationToken);
            return true;
        }
    }
}
