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
    public class ActualizarMarcaCommand: IRequest<bool>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class ActualizarMarcaCommandHandler : IRequestHandler<ActualizarMarcaCommand, bool>
    {
        private readonly IRepository<Marca> _repository;
        public ActualizarMarcaCommandHandler(IRepository<Marca> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(ActualizarMarcaCommand request, CancellationToken cancellationToken)
        {
            var marca = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (marca == null)
            {
                return false;
            }
            marca.Nombre = request.Nombre;
            var updated = await _repository.UpdateAsync(marca, cancellationToken);
            return updated;
        }
    }
}
