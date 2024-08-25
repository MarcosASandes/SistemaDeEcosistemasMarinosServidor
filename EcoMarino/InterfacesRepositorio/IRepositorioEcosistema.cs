using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.InterfacesRepositorio
{
    public interface IRepositorioEcosistema : IRepositorio<Ecosistema>
    {
        public List<Ecosistema> GetEcosistemasInadecuados(Especie unaEspecie);
        public List<Especie> GetEspeciesDeEcosistema(int idEco);
        public List<string> GetImagenesDeEcosistema(int idEco);
        public string GetPrimerImagen(int idEco);
    }
}
