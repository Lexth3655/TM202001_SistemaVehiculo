using MediatR;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Repository;

namespace Core.Features.Br.Commands
{
    public class CrearMarcaCommands: IRequest<Marca>
    {
        public string Nombre { get; set; }

    }

    public class CrearMarcaCommandsHandler : IRequestHandler<CrearMarcaCommands, Marca>
    {
        private readonly IRepository<Marca> _repository;
        public CrearMarcaCommandsHandler(IRepository<Marca> repository)
        {
            _repository = repository;
        }
        public async Task<Marca> Handle(CrearMarcaCommands request, CancellationToken cancellationToken)
        {
            var marca = new Marca
            {
                Nombre = request.Nombre
            };
            await _repository.AddAsync(marca, cancellationToken);
            return marca;
        }
    }
}
