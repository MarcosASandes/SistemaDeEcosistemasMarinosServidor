using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.AccesoDatos.InMemory
{
    public class AmenazaRepoMemoria : IRepositorioAmenaza
    {
        private static List<Amenaza> _amenazas = new List<Amenaza>();
        private static List<EcosistemaAmenaza> _amenazasEco = new List<EcosistemaAmenaza>();
        private static List<EspecieAmenaza> _amenazasEsp = new List<EspecieAmenaza>();

        public AmenazaRepoMemoria()
        {
            
        }
        public void Add(Amenaza obj)
        {
            try
            {
                //obj.Validar();
                _amenazas.Add(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(Amenaza obj)
        {
            throw new NotImplementedException();
        }

        public List<Amenaza> FindAll()
        {
            return _amenazas;
        }

        public Amenaza FindById(int id)
        {
            Amenaza ret = null;
            foreach(Amenaza a in _amenazas)
            {
                if(a.Id == id)
                {
                    ret = a;
                }
            }
            return ret;
        }

        public List<Amenaza> GetAmenazasPorEcosistemaId(int idEco)
        {
            List<EcosistemaAmenaza> aux = _amenazasEco;
            List<Amenaza> ret = new List<Amenaza>();
            foreach(EcosistemaAmenaza ea in aux)
            {
                if(ea.EcosistemaId == idEco)
                {
                    ret.Add(ea.Amenaza);
                }
            }
            return ret;
        }

        public List<Amenaza> GetAmenazasPorEspecieId(int idEsp)
        {
            List<EspecieAmenaza> aux = _amenazasEsp;
            List<Amenaza> ret = new List<Amenaza>();
            foreach (EspecieAmenaza ea in aux)
            {
                if (ea.idEspecie == idEsp)
                {
                    ret.Add(ea.Amenaza);
                }
            }
            return ret;
        }

        public void Update(Amenaza obj)
        {
            throw new NotImplementedException();
        }
    }
}
