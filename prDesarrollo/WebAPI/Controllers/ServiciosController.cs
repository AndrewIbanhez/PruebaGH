using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class ServiciosController : ControllerBase{
    private readonly IMediator mediador; 
    public ServiciosController(IMediator mediador){
        this.mediador = mediador;
    }

    [HttpGet]
    public async Task<ActionResult<List<ServicioModel>>> ObtenerServicios(){
        return await mediador.Send(new Aplicacion.Servicios.Consulta.Lista());
    }

    [HttpPost]
    public async Task<ActionResult<Unit>>CrearServicio(Aplicacion.Servicios.Crear.Ejecuta data){
        return await mediador.Send(data);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Unit>> ActualizarServicio(Guid id, Aplicacion.Servicios.Editar.Ejecuta data){
        data.codServicio = id;
        return await mediador.Send(data);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> EliminarRegistro(Guid id){
        return await mediador.Send(new Aplicacion.Servicios.Eliminar.Ejecuta{codServicio = id});
    }
}