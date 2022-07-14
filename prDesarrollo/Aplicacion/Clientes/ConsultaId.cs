using MediatR;

public class ConsultaId{
    public class ClienteUnico : IRequest<Cliente>{
        public Guid id {get;set;}
    }

    public class Manejador : IRequestHandler<ClienteUnico, Cliente>
    {
        private readonly DBContext context;
        public Manejador(DBContext context){
            this.context = context;
        }
        public async Task<Cliente> Handle(ClienteUnico request, CancellationToken cancellationToken)
        {
            var cliente = await context.Cliente.FindAsync(request.id);
            return cliente;
        }
    }
}