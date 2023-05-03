using Microsoft.EntityFrameworkCore;
using CIMA.Context;
using CIMA.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CIMADbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConnection");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.MapAsistenteEndpoints();
app.MapSesionEndpoints();
app.MapAsistentesPorSesionEndpoints();

app.Run();
