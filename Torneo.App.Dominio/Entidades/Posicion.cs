using System.ComponentModel.DataAnnotations;
namespace Torneo.App.Dominio
{
    public class Posicion
    {
        public int Id { get; set; }
        [Display(Name = "Nombre posicion")]
        [Required(ErrorMessage = "El nombre de la posicion jugador es Obligatoria")]
        public string Nombre { get; set; }
    }
}