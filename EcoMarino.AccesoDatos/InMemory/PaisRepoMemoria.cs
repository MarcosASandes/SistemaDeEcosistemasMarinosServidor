using EcoMarino.Entidades;
using EcoMarino.Exceptions;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.InMemory
{
    public class PaisRepoMemoria : IRepositorioPais
    {
        private static List<Pais> _paises = new List<Pais>();

        public PaisRepoMemoria()
        {
            _paises.Add(new Pais("Uruguay", "URU"));
            _paises.Add(new Pais("Argentina", "ARG"));
            _paises.Add(new Pais("Brasil", "BRA"));
        }
        public void Add(Pais obj)
        {
            try
            {
                //obj.Validar();
                _paises.Add(obj);
            }
            catch (PaisException pEx)
            {
                throw new PaisException("Error al agregar el país. Detalles: " + pEx.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Pais obj)
        {
            throw new NotImplementedException();
        }

        public List<Pais> FindAll()
        {
            throw new NotImplementedException();
        }

        public Pais FindByCod(string id)
        {
            throw new NotImplementedException();
        }

        public Pais FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}
