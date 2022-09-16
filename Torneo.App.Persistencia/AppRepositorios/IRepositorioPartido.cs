using System;
using Torneo.App.Dominio; 
namespace Torneo.App.Persistencia
{
    public interface IRepositorioPartido
    {
        public Partido AddPartido(Partido partido, int idLocal, int idVisitante);
        
        public IEnumerable<Partido> GetAllPartidos();
            
        public Partido GetPartido(int idPartido);
        public Partido UpdatePartido(Partido partido, int idLocal, int idVisitante);
        
    }
}
