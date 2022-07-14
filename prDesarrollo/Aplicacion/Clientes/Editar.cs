using System.Net;
using MediatR;

public class Editar{
    public class Ejecuta : IRequest{
        public Guid codCliente {get;set;}
        public string nombre {get;set;} = null!;
        public string apellido {get;set;} = null!;
        public string direccion {get;set;} = null!; 
        public string telefono {get;set;}  = null!;
    }

    public class Manejador : IRequestHandler<Ejecuta>
    {
        private readonly DBContext context; 
        public Manejador(DBContext context){
            this.context = context;
        }
        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var cliente = await context.Cliente.FindAsync(request.codCliente);
            if(cliente == null)
                throw new Exception("Registro no encontrado");
            
            cliente.nombre = request.nombre ?? cliente.nombre; 
            cliente.apellido = request.apellido ?? cliente.apellido; 
            cliente.direccion = request.direccion ?? cliente.direccion;

            var resultado = await context.SaveChangesAsync();

            if(resultado > 0)
                return Unit.Value;           

            throw new Exception("No se pudo modificar el registro");

        }
    }
}