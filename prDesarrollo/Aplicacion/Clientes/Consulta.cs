using MediatR;
using Microsoft.EntityFrameworkCore;

public class Consulta{
    public class ListaClientes : IRequest<List<Cliente>>{}

    public class Manejador : IRequestHandler<ListaClientes, List<Cliente>>
    {
        private readonly DBContext context;
        public Manejador(DBContext context){
            this.context = context;
        }
        public async Task<List<Cliente>> Handle(ListaClientes request, CancellationToken cancellationToken)
        {
            var clientes = await context.Cliente.ToListAsync();
            return clientes;
        }
    }
}