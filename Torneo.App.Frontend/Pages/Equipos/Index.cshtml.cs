using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Equipos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioMunicipio _repoMunicipio;  // filtros
        public IEnumerable<Equipo> equipos { get; set; }
        public SelectList MunicipioOptions { get; set; }   // filtros
        public int MunicipioSelected { get; set; } // filtros
        public string BusquedaActual { get; set; } // busquedas


        // inserto un atrib para filtros municipio
        public IndexModel(IRepositorioEquipo repoEquipo, IRepositorioMunicipio repoMunicipio)
        {
            _repoEquipo = repoEquipo;
            _repoMunicipio = repoMunicipio;
        }

        public void OnGet()
        {
            MunicipioOptions = new SelectList(_repoMunicipio.GetAllMunicipios(), "Id", "Nombre"); // filtros
            equipos = _repoEquipo.GetAllEquipos();
            MunicipioSelected = -1;  // filtros ocpion verTodos 
            BusquedaActual = ""; // busquedas
        }
        // filtros
        public void OnPostFiltro(int idMunicipio)
        {
            MunicipioOptions = new SelectList(_repoMunicipio.GetAllMunicipios(), "Id", "Nombre");
            if (idMunicipio != -1)
            {
                MunicipioSelected = idMunicipio;
                equipos = _repoEquipo.GetEquiposMunicipio(MunicipioSelected);
            }
            else
            {
                equipos = _repoEquipo.GetAllEquipos();
                MunicipioSelected = -1;
            }
        }
        // busquedas
        public void OnPostBuscar(string nombre)
        {
            MunicipioOptions = new SelectList(_repoMunicipio.GetAllMunicipios(), "Id", "Nombre");
            MunicipioSelected = -1;
            if (string.IsNullOrEmpty(nombre))
            {
                BusquedaActual = "";
                equipos = _repoEquipo.GetAllEquipos();
            }
            else
            {
                BusquedaActual = nombre;
                equipos = _repoEquipo.SearchEquipos(nombre);
            }
        }
    }
}
