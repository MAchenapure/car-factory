using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Api.Filters;
using Microsoft.OpenApi.Models;
using CarFactory.Sales.Application.Common;

var builder = WebApplication.CreateBuilder(args);

// Registra controllers con filtro de medición de tiempo de ejecución
builder.Services.AddControllers(options => options.Filters.Add<ExecutionTimeFilter>());
builder.Services.AddEndpointsApiExplorer();

// Inyección de dependencias
builder.Services.AddSingleton<ISalesRepository, CarFactory.Sales.Infrastructure.Repositories.InMemoryRepository>();

// Configuración de MediatR 
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly,
        typeof(AssemblyMarker).Assembly
    )
);

// Configuración de Swagger
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarFactory.Sales API", Version = "v1" }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();

public partial class Program { }