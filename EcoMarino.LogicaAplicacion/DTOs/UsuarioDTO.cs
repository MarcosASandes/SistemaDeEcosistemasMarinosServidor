using EcoMarino.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoMarino.LogicaAplicacion.DTOs
{
    public class UsuarioDTO
    {
        public string? token { get; set; }
        public int id { get; set; }
        public string alias { get; set; }
        public string passNormal { get; set; }
        //public string passEncriptada { get; set; }
        public bool esAdmin { get; set; }
        //public DateTime? fechaIngreso { get; set; }

        public UsuarioDTO() { }

        public UsuarioDTO(Usuario usuario)
        {
            this.id = usuario.Id;
            this.alias = usuario.Alias;
            //this.passEncriptada = usuario.PassEncriptada;
            this.passNormal = Seguridad.Desencriptar(usuario.PassEncriptada);
            //this.esAdmin = usuario.EsAdmin;
            //this.fechaIngreso = usuario.FechaIngreso;
        }

        public UsuarioDTO(int id, string alias, string passEncriptada, bool esAdmin, DateTime fecha)
        {
            this.id=id;
            this.alias = alias;
            //this.passEncriptada=passEncriptada;
            this.passNormal = Seguridad.Desencriptar(passEncriptada);
            //this.esAdmin = esAdmin;
            //this.fechaIngreso=fecha;
        }


    }
}
