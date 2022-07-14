using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DBContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddOptions();
builder.Services.Configure<ConexionConfiguracion>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddMediatR(typeof (Consulta.Manejador).Assembly);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IFactoryConnection, FactoryConnection>();
builder.Services.AddScoped<IServicio, ServiciosRepositorio>();

var app = builder.Build();

 using(var ambiente = app.Services.CreateScope()){
            var services = ambiente.ServiceProvider;

            try{
                //Insertar data de prueba
                var context = services.GetRequiredService<DBContext>();
                context.Database.Migrate();
            }catch(Exception e){
                var logging = services.GetRequiredService<ILogger<Program>>();
                logging.LogError(e, "Ocurrió un error en la migración"); 
            }

        }

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
