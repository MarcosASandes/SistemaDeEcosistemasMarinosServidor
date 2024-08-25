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
    public class LoginUserCU : ILoginUserCU
    {
        private IRepositorioUsuario repositorioUsuario;

        public LoginUserCU(IRepositorioUsuario repoUser)
        {
            this.repositorioUsuario = repoUser;
        }

        public UsuarioDTO Login(string unAlias, string pass)
        {
            try
            {
                Usuario userEntidad = repositorioUsuario.GetUserPorLogin(unAlias, pass);
                UsuarioDTO us = new UsuarioDTO();

                if (userEntidad != null)
                {
                    //us.fechaIngreso = userEntidad.FechaIngreso;
                    us.id = userEntidad.Id;
                    us.alias = userEntidad.Alias;
                    us.passNormal = userEntidad.PassNormal;
                    //us.passEncriptada = userEntidad.PassEncriptada;
                    us.esAdmin = userEntidad.EsAdmin;
                    return us;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
