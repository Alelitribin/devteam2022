using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Posiciones
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioPosicion _repoPosicion;
        public IEnumerable<Posicion> posiciones { get; set; }

        public IndexModel(IRepositorioPosicion repoPosicion)
        {
            _repoPosicion = repoPosicion;
        }

        public void OnGet()
        {
            posiciones = _repoPosicion.GetAllPosiciones();
        }

         public IActionResult OnPost(Posicion pos)
        {
            if (ModelState.IsValid)
            {
                _repoPosicion.AddPosicion(pos);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
