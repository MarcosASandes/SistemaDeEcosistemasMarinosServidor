using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.InMemory
{
    public class EcosistemaRepoMemoria : IRepositorioEcosistema
    {
        private static List<Ecosistema> _ecosistemas = new List<Ecosistema>();

        public EcosistemaRepoMemoria()
        {

        }
        public void Add(Ecosistema obj)
        {
            try
            {
                //obj.Validar();
                _ecosistemas.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Ecosistema obj)
        {
            throw new NotImplementedException();
        }

        public List<Ecosistema> FindAll()
        {
            return _ecosistemas;
        }

        public Ecosistema FindById(int id)
        {
            Ecosistema Eco = null;
            foreach(Ecosistema e in _ecosistemas)
            {
                if (e.Id == id)
                {
                    Eco = e;
                }
            }
            return Eco;
        }

        public List<Ecosistema> GetEcosistemasInadecuados(Especie unaEspecie)
        {
            throw new NotImplementedException();
        }

        public List<Especie> GetEspeciesDeEcosistema(int idEco)
        {
            throw new NotImplementedException();
        }

        public List<string> GetImagenesDeEcosistema(int idEco)
        {
            throw new NotImplementedException();
        }

        public string GetPrimerImagen(int idEco)
        {
            throw new NotImplementedException();
        }

        public void Update(Ecosistema obj)
        {
            throw new NotImplementedException();
        }
    }
}
