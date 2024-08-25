using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.InMemory
{
    public class EspecieRepoMemoria : IRepositorioEspecie
    {
        private static List<Especie> _especies = new List<Especie>();

        public EspecieRepoMemoria()
        {

        }
        public void Add(Especie obj)
        {
            try
            {
                //obj.Validar();
                _especies.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Especie obj)
        {
            throw new NotImplementedException();
        }

        public List<Especie> FindAll()
        {
            return _especies;
        }

        public Especie FindById(int id)
        {
            Especie Esp = null;
            foreach (Especie e in _especies)
            {
                if (e.Id == id)
                {
                    Esp = e;
                }
            }
            return Esp;
        }

        public List<Ecosistema> GetEcosistemasDeEspecie(int idEsp)
        {
            throw new NotImplementedException();
        }

		public List<Ecosistema> GetEcosistemasHabitables(int idEsp)
		{
			throw new NotImplementedException();
		}

		public List<Especie> GetEspeciePorEcosistema(Ecosistema unEcosistema)
        {
            throw new NotImplementedException();
        }

        public List<Especie> GetEspeciePorNombre(string unNombre)
        {
            throw new NotImplementedException();
        }

        public List<Especie> GetEspeciesEnPeligroDeExtincion()
        {
            throw new NotImplementedException();
        }

        public List<Especie> GetEspeciesPorNombreYPeso(string nombre, double pesoMinimo, double pesoMaximo)
        {
            throw new NotImplementedException();
        }

        public List<Especie> GetEspeciesPorRangoPeso(double pesoMinimo, double pesoMaximo)
        {
            throw new NotImplementedException();
        }

        public List<string> GetImagenesDeEspecie(int idEsp)
        {
            throw new NotImplementedException();
        }

        public string GetPrimerImagen(int idEsp)
        {
            throw new NotImplementedException();
        }

        public void Update(Especie obj)
        {
            throw new NotImplementedException();
        }
    }
}
