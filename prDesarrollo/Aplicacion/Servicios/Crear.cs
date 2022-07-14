using MediatR;

namespace Aplicacion.Servicios
{
    public class Crear
    {
        public class Ejecuta : IRequest{
            public string nombre {get;set;} = null!;
            public string descripcion {get;set;} = null!;
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IServicio servicioRepositorio;
            public Manejador(IServicio servicioRepositorio){
                this.servicioRepositorio = servicioRepositorio;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var resultado = await servicioRepositorio.CrearServicio(request.nombre, request.descripcion);

                if(resultado > 0)
                    return Unit.Value;
                
                throw new Exception("No se pudo insertar el nuevo registro");
            }
        }
    }
}