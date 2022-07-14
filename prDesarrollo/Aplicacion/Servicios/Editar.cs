using MediatR;

namespace Aplicacion.Servicios
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid codServicio {get;set;}
            public string nombre {get;set;} 
            public string descripcion{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IServicio servicioRepositorio; 
            public Manejador(IServicio servicioRepositorio){
                this.servicioRepositorio = servicioRepositorio;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var resultado = await servicioRepositorio.ActualizarServicio(request.codServicio, request.nombre, request.descripcion);

                if (resultado > 0)
                    return Unit.Value; 

                throw new Exception("No fue posible actualizar el registro");
            }
        }
    }
}