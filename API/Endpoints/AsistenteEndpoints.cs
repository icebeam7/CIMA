using CIMA.Context;
using CIMA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CIMA.Endpoints
{
    public static class AsistenteEndpoints
    {
        static string endpoint = "/api/asistente";

        public static void MapAsistenteEndpoints(this WebApplication app)
        {
            app.MapGet(endpoint, async (CIMADbContext db) =>
                await db.Asistentes.ToListAsync()
            );

            app.MapGet(endpoint + "/{id}", async (CIMADbContext db, int id) =>
            {
                return await db.Asistentes.FindAsync(id)
                    is Asistente data ? Results.Ok(data) : Results.NotFound();
            });

            app.MapPost(endpoint, async ([FromBody] Asistente data,
                [FromServices] CIMADbContext db) =>
            {
                db.Asistentes.Add(data);
                await db.SaveChangesAsync();
                return Results.Ok(data);
            });

            app.MapPut(endpoint + "/{id}", async (int id,
                [FromBody] Asistente data,
                [FromServices] CIMADbContext db) =>
            {
                if (id != data.Id_Asistente)
                    return Results.BadRequest();

                db.Entry(data).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.NotFound();
                }
            });

            app.MapDelete(endpoint + "/{id}", async (int id,
                [FromServices] CIMADbContext db) =>
            {
                var data = await db.Asistentes.FindAsync(id);

                if (data == null)
                    return Results.NotFound();

                db.Asistentes.Remove(data);

                await db.SaveChangesAsync();
                return Results.Ok(data);
            });
        }
    }
}