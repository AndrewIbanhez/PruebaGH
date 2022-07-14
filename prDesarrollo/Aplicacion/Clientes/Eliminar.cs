using System.Net;
using MediatR;

public class Eliminar{
    public class Ejecuta : IRequest{
        public Guid id {get;set;}
    }

    public class Manejador : IRequestHandler<Ejecuta>
    {
        private readonly DBContext context; 
        public Manejador(DBContext context){
            this.context = context;
        }
        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var cliente = await context.Cliente.FindAsync(request.id);
            if(cliente == null)
                throw new Exception("No se encontró el registro");
            
            context.Remove(cliente); 
            var resultado = await context.SaveChangesAsync(); 

            if(resultado > 0)
                return Unit.Value; 
            
            throw new Exception("No fue posible eliminar el registro");
        }
    }
}