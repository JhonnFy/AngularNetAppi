using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    internal class ReglasNegocioHelper
    {
        public static string HleperOmitirAcentos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return texto;

            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(texto);
            return Encoding.ASCII.GetString(bytes);
        }


        public static string HelperNombresEstudiantes(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return nombre;

            var partes = nombre.Split(' ');
            partes[0] = char.ToUpper(partes[0][0]) + partes[0].Substring(1).ToLower();
            return string.Join(" ", partes);
        }


        public static string HelperNombreProfesores(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return nombre;

            var partes = nombre.Split(' ');
            partes[0] = char.ToUpper(partes[0][0]) + partes[0].Substring(1).ToLower();

            for (int i = 1; i < partes.Length; i++)
                partes[i] = partes[i].ToLower();

            return string.Join(" ", partes);
        }

        public static decimal HelperAjustarValoresNotas(decimal valor)
        {
            return valor == 4.2m ? 5.0m : valor;
        }


    }
}
