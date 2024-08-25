using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.InterfacesRepositorio
{
    public interface IRepositorioEspecie : IRepositorio<Especie>
    {
        public List<Especie> GetEspeciePorNombre(string unNombre);

        public List<Especie> GetEspeciesEnPeligroDeExtincion();

        public List<Especie> GetEspeciesPorRangoPeso(double pesoMinimo, double pesoMaximo);

        public List<Especie> GetEspeciePorEcosistema(Ecosistema unEcosistema);

        public List<Especie> GetEspeciesPorNombreYPeso(string nombre, double pesoMinimo, double pesoMaximo);

        public List<Ecosistema> GetEcosistemasDeEspecie(int idEsp);
        public List<Ecosistema> GetEcosistemasHabitables(int idEsp);

        public List<string> GetImagenesDeEspecie(int idEsp);
        public string GetPrimerImagen(int idEsp);
    }
}
