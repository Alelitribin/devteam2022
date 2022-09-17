using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Jugadores

{
     public class EditModel : PageModel
     {
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioPosicion _repoPosicion;
        
        public Jugador jugador { get; set; }
        public SelectList equipoOptions { get; set; }
        public SelectList posicionOptions { get; set; }
        
        public int equipoSelected { get; set; }
        public int posicionSelected { get; set; }
       
        public EditModel(IRepositorioJugador repoJugador, IRepositorioEquipo repoEquipo, IRepositorioPosicion repoPosicion)
       
        {
            _repoJugador = repoJugador;
            _repoEquipo = repoEquipo;
            _repoPosicion = repoPosicion;
            
        }
        public IActionResult OnGet(int id)
        {
            jugador = _repoJugador.GetJugador(id);
            equipoOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            equipoSelected =jugador.Equipo.Id;
            posicionOptions = new SelectList(_repoPosicion.GetAllPosiciones(), "Id", "Nombre");
            posicionSelected = jugador.Posicion.Id;
           
           
            if (jugador == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Jugador jugador, int idEquipo, int idPosicion)
        {
            _repoJugador.UpdateJugador(jugador, idEquipo, idPosicion);
            return RedirectToPage("Index");
        }
     }
}
