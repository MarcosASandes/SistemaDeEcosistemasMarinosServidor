using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace EcoMarino.Entidades
{
    public static class Seguridad
    {

        #region Encriptación
        public static string Encriptar(string pass)
        {
            string hash = "encriptacioncon";
            byte[] data = Encoding.UTF8.GetBytes(pass);

            MD5 md5Protocol = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5Protocol.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform objTransform = tripledes.CreateEncryptor();

            byte[] resultado = objTransform.TransformFinalBlock(data, 0, data.Length);

            return Convert.ToBase64String(resultado);
        }
        #endregion

        #region Desencriptación
        public static string Desencriptar(string passEncriptada)
        {
            string hash = "encriptacioncon";
            byte[] data = Convert.FromBase64String(passEncriptada);

            MD5 md5Protocol = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5Protocol.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform objTransform = tripledes.CreateDecryptor();

            byte[] resultado = objTransform.TransformFinalBlock(data, 0, data.Length);

            return UTF8Encoding.UTF8.GetString(resultado);
        }
        #endregion
    }
}
