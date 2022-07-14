using MediatR;

public class Crear{
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
           var cliente = new Cliente{
             codCliente = Guid.NewGuid(), 
             nombre = request.nombre, 
             apellido = request.apellido, 
             direccion = request.direccion, 
             telefono = request.telefono
           };

           context.Cliente.Add(cliente);
           var response = await context.SaveChangesAsync();

           if(response > 0)
             return Unit.Value;

            throw new Exception("No se pudo insertar el registro en la base de datos");

        }
    }
}