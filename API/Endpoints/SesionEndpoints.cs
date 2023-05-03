using CIMA.Context;
using CIMA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CIMA.Endpoints
{
    public static class SesionEndpoints
    {
        static string endpoint = "/api/sesion";

        public static void MapSesionEndpoints(this WebApplication app)
        {
            app.MapGet(endpoint, async (CIMADbContext db) =>
                await db.Sesiones.ToListAsync()
            );

            app.MapGet(endpoint + "/{id}", async (CIMADbContext db, int id) =>
            {
                return await db.Sesiones.FindAsync(id)
                    is Sesion data ? Results.Ok(data) : Results.NotFound();
            });

            app.MapPost(endpoint, async ([FromBody] Sesion data,
                [FromServices] CIMADbContext db) =>
            {
                db.Sesiones.Add(data);
                await db.SaveChangesAsync();
                return Results.Ok(data);
            });

            app.MapPut(endpoint + "/{id}", async (int id,
                [FromBody] Sesion data,
                [FromServices] CIMADbContext db) =>
            {
                if (id != data.Id_Sesion)
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
                var data = await db.Sesiones.FindAsync(id);

                if (data == null)
                    return Results.NotFound();

                db.Sesiones.Remove(data);

                await db.SaveChangesAsync();
                return Results.Ok(data);
            });
        }
    }
}