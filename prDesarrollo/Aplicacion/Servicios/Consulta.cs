using MediatR;

namespace Aplicacion.Servicios
{
    public class Consulta
    {
        public class Lista : IRequest<List<ServicioModel>>{}

        public class Manejador : IRequestHandler<Lista, List<ServicioModel>>
        {
            private readonly IServicio servicioRepositorio; 
            public Manejador(IServicio servicioRepositorio){
                this.servicioRepositorio = servicioRepositorio;
            }
            public async Task<List<ServicioModel>> Handle(Lista request, CancellationToken cancellationToken)
            {
                var resultado = await servicioRepositorio.ObtenerServicios();
                return resultado.ToList();
            }
        }
    }
}