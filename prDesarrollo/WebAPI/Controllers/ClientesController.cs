using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
[ApiController]
public class ClientesController: ControllerBase{

    private readonly IMediator mediador;
    public ClientesController(IMediator mediador){
        this.mediador = mediador;
    }

    [HttpGet]
    public async Task<ActionResult<List<Cliente>>> ObtenerClietnes(){
        return await mediador.Send(new Consulta.ListaClientes());
    }

     [HttpGet("{id}")]
     public async Task<ActionResult<Cliente>> ObtenerClientexId(Guid id){
        return await mediador.Send(new ConsultaId.ClienteUnico{id = id});
     }

    [HttpPost]
    public async Task<ActionResult<Unit>> CrearCliente(Crear.Ejecuta data){
        return await mediador.Send(data);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Unit>> ActualizarCliente(Guid id, Editar.Ejecuta data){
        data.codCliente = id;
        return await mediador.Send(data);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> EliminarCliente(Guid id){
        return await mediador.Send(new Eliminar.Ejecuta{id = id});
    }
}