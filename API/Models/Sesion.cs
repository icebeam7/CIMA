using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIMA.Models;

[Table("Sesion")]
public class Sesion
{
    [Key]
    public int Id_Sesion { get; set; }
    public string Nombre { get; set; }
}