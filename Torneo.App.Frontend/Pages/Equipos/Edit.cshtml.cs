using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Equipos
{
    public class EditModel : PageModel
    {

        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioDT _repoDT;

        public Equipo Equipo {get; set;}
        public DirectorTecnico dt {get; set;}
        public SelectList DTOptions {get; set;}
        public int DTSelected {get; set;}
        public EditModel(IRepositorioEquipo repoEquipo, IRepositorioDT repoDT)
        {
            _repoEquipo = repoEquipo;
            _repoDT = repoDT;
        }
        
        public IActionResult OnGet(int id){
            Equipo = _repoEquipo.GetEquipo(id);
            DTOptions = new SelectList(_repoDT.GetAllDTs(), "Id", "Nombre");
            DTSelected = Equipo.DT.Id;    //DTSelected =DT.Equipo.Id;
            if (Equipo == null){
                return NotFound();
            }
            else{
                return Page();
            }
        }
        public IActionResult OnPost(Equipo Equipo, int idDT)
        {
            _repoEquipo.UpdateEquipo(Equipo, idDT);
            return RedirectToPage("Index");
        }
    }
}