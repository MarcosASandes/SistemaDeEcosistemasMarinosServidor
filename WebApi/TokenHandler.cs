using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using EcoMarino.LogicaAplicacion.DTOs;
using EcoMarino.InterfacesRepositorio;
using EcoMarino.LogicaAplicacion.InterfacesCU;

namespace WebApi
{
    public class TokenHandler
    {
        private IObtenerUserPorAliasCU getUserPorAlias { get; set; }


        public TokenHandler(IObtenerUserPorAliasCU getus)
        {
            this.getUserPorAlias = getus;
        }




        public static string GenerarToken(UsuarioDTO user, IConfiguration configuration)
        {


            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.alias)
            };

            var claveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:SecretTokenKey").Value!));
            var credenciales = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: credenciales);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }



        public UsuarioDTO ObtenerUsuario(string alias)
        {
            return getUserPorAlias.getUserPorAlias(alias);
        }

    }
}
