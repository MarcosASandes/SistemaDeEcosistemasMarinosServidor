using EcoMarino.Entidades;
using EcoMarino.Exceptions;
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
    public class RegistroUserCU : IRegistroUserCU
    {
        private IRepositorioUsuario repositorioUsuario;
        private IAddControlCambioCU CambiosCU;

        public RegistroUserCU(IRepositorioUsuario repoUser, IAddControlCambioCU cambiosRepositorio)
        {
            this.repositorioUsuario = repoUser;
            this.CambiosCU = cambiosRepositorio;
        }


        public UsuarioDTO RegistrarUsuario(UsuarioDTO unUser, string aliasCambio)
        {
            try
            {
                Usuario us = new Usuario();
                us.Alias = unUser.alias;
                us.PassEncriptada = Seguridad.Encriptar(unUser.passNormal);
                us.PassNormal = unUser.passNormal;
                us.EsAdmin = false;
                us.FechaIngreso = DateTime.Now;
                us.ValidarUsuario();
                repositorioUsuario.Add(us);
                ControlCambios nuevoCambio = new ControlCambios(aliasCambio, DateTime.Now, us.Id, "Usuario");
                CambiosCU.RegistrarCambio(nuevoCambio);
                return new UsuarioDTO(us);
            }
            catch (UsuarioException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
