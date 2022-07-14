using MediatR;

namespace Aplicacion.Servicios
{
    public class Eliminar
    {
        public class Ejecuta : IRequest{
            public Guid codServicio {get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IServicio servicioRepositorio; 
            public Manejador(IServicio servicioRepositorio){
                this.servicioRepositorio = servicioRepositorio;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var resultados = await servicioRepositorio.EliminarServicio(request.codServicio);

                if(resultados > 0)
                    return Unit.Value;
                
                throw new Exception("No fue posible eliminar el registro");
            }
        }
    }
}