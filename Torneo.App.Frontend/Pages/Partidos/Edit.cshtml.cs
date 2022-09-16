using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Partidos

{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;
        //private readonly IRepositorioArbitro _repoArbitro;
        //private readonly IRepositorioEstadio _repoEstadio;
        //private readonly IRepositorioNovedad _repoNovedad;

        public Partido partido { get; set; }
        public SelectList equipoLocalOptions { get; set; }
        public SelectList equipoVisitanteOptions { get; set; }
        //public SelectList arbitroOptions { get; set; }
        //public SelectList estadioOptions { get; set; }
        //public SelectList novedadOptions { get; set; }

        public int equipoLocalSelected { get; set; }
        public int equipoVisitanteSelected { get; set; }
        //public int arbitroSelected { get; set; }
        //public int estadioSelected { get; set; }
        //public int novedadSelected { get; set; }

        public EditModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo)
        //, IRepositorioArbitro repoArbitro, IRepositorioEstadio repoEstadio, //IRepositorioNovedad repoNovedad)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
            //_repoArbitro = repoArbitro;
            //_repoEstadio = repoEstadio;
            //_repoNovedad = repoNovedad;
        }

        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            equipoLocalOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            equipoLocalSelected = partido.Local.Id;
            
            equipoVisitanteOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            equipoVisitanteSelected = partido.Visitante.Id;
           
            if (partido == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Partido partido, int idLocal, int idVisitante)
        {
            _repoPartido.UpdatePartido(partido, idLocal, idVisitante);
            return RedirectToPage("Index");
        }
    }
}