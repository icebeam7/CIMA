using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIMA.Models;

[Table("Asistente")]
public class Asistente
{
    [Key]
    public int Id_Asistente { get; set; }
    public string Nombre { get; set; }
    public DateTime Fecha_Asistencia { get; set; }
}