using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.DTs
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public DirectorTecnico DT { get; set; }

        public DetailsModel(IRepositorioDT repoDT)
        {
            _repoDT = repoDT;
        }

        public IActionResult OnGet(int id)
        {
            DT = _repoDT.GetDT(id);
            if (DT == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
