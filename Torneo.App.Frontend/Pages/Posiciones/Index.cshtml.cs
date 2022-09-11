using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Posiciones
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioPosicion _repoPosicion;
        public Posiciones pos { get; set; }

        public CreateModel(IRepositorioPosicion repoPosicion)
        {
            _repoPosicion = repoPosicion;
        }

        public void OnGet()
        {
            pos = new Posicion();
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
