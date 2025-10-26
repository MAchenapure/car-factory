using CarFactory.Sales.Application.Interfaces;
using CarFactory.Sales.Api.Filters;
using Microsoft.OpenApi.Models;
using CarFactory.Sales.Application.Common;

var builder = WebApplication.CreateBuilder(args);

// Registra controllers con filtro de medici�n de tiempo de ejecuci�n
builder.Services.AddControllers(options => options.Filters.Add<ExecutionTimeFilter>());
builder.Services.AddEndpointsApiExplorer();

// Inyecci�n de dependencias
builder.Services.AddSingleton<ISalesRepository, CarFactory.Sales.Infrastructure.Repositories.InMemoryRepository>();

// Configuraci�n de MediatR 
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly,
        typeof(AssemblyMarker).Assembly
    )
);

// Configuraci�n de Swagger
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