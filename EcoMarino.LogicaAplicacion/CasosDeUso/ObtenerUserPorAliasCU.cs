using EcoMarino.Entidades;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.CasosDeUso
{
    public class ObtenerUserPorAliasCU : IObtenerUserPorAliasCU
    {
        private IRepositorioUsuario UserRepositorio { get; set; }
        public ObtenerUserPorAliasCU(IRepositorioUsuario userRepositorio)
        {
            UserRepositorio = userRepositorio;
        }

        public UsuarioDTO getUserPorAlias(string alias)
        {
            Usuario us = UserRepositorio.GetUserPorAlias(alias);
            if(us != null)
            {
                UsuarioDTO ret = new UsuarioDTO();
                ret.id = us.Id;
                //ret.fechaIngreso = us.FechaIngreso;
                //ret.passEncriptada = us.PassEncriptada;
                ret.passNormal = us.PassNormal;
                ret.alias = us.Alias;

                return ret;
            }
            else
            {
                return null;
            }
        }


    }
}
