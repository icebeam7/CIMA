using System.ComponentModel.DataAnnotations.Schema;

namespace CIMA.Models;

[Table("AsistentesPorSesion")]
public class AsistentesPorSesion
{
    public int Id_Asistente { get; set; }
    public int Id_Sesion { get; set; }
}