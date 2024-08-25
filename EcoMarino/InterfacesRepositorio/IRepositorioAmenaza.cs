using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.InterfacesRepositorio
{
    public interface IRepositorioAmenaza : IRepositorio<Amenaza>
    {
        public List<Amenaza> GetAmenazasPorEcosistemaId(int idEco);
        public List<Amenaza> GetAmenazasPorEspecieId(int idEsp);
    }
}
