using CIMA.Context;
using CIMA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CIMA.Endpoints
{
    public static class AsistentesPorSesionEndpoints
    {
        static string endpoint = "/api/asistentesporsesion";

        public static void MapAsistentesPorSesionEndpoints(this WebApplication app)
        {
            app.MapGet(endpoint, async (CIMADbContext db) =>
                await db.AsistentesPorSesion.ToListAsync()
            );

            app.MapPost(endpoint, async ([FromBody] AsistentesPorSesion data,
                [FromServices] CIMADbContext db) =>
            {
                db.AsistentesPorSesion.Add(data);
                await db.SaveChangesAsync();
                return Results.Ok(data);
            });

            app.MapGet(endpoint + "/{id}", async (CIMADbContext db, int id) =>
            {
                return await db.AsistentesPorSesion
                                .Where(x => x.Id_Asistente == id)
                                .ToListAsync()
                    is List<AsistentesPorSesion> data ? Results.Ok(data) : Results.NotFound();
            });            

            app.MapDelete(endpoint + "/{id}", async (int id, 
                [FromServices] CIMADbContext db) =>
            {
                var data = await db.AsistentesPorSesion
                                .Where(x => x.Id_Asistente == id)
                                .ToListAsync();

                if (data == null)
                    return Results.NotFound();

                db.AsistentesPorSesion.RemoveRange(data);

                await db.SaveChangesAsync();
                return Results.Ok(data);
            });
        }
    }
}