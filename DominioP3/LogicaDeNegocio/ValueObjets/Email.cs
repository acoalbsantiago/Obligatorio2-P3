using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaDeNegocio.ValueObjets
{
    [Owned]
    public class Email
    {
        public string Correo { get; private set; }

        public Email() { }

        private Email(string correo)
        {
            Correo = correo.ToLower();
        }

        private static string NormalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;

            var normalized = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sinTildes = new StringBuilder();
            foreach (var c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    sinTildes.Append(c);
            }
           
            string limpio = sinTildes.ToString()
                .Replace('ñ', 'n')
                .Replace('Ñ', 'n');

            limpio = Regex.Replace(limpio, @"[^a-zA-Z]", "");

            return limpio.ToLower();
        }

        public static Email Crear(string nombre, string apellido)
        {
            nombre = NormalizarTexto(nombre);
            apellido = NormalizarTexto(apellido);

            string prefNombre = nombre.Length >= 3 ? nombre[..3] : nombre;
            string prefApellido = apellido.Length >= 3 ? apellido[..3] : apellido;

            string correo = $"{prefNombre}{prefApellido}@laempresa.com";
            return new Email(correo);
        }

        public static Email CrearSecundario(string nombre, string apellido)
        {
            nombre = NormalizarTexto(nombre);
            apellido = NormalizarTexto(apellido);

            Random random = new Random();
            int numRandom = random.Next(100, 999);

            string prefNombre = nombre.Length >= 3 ? nombre[..3] : nombre;
            string prefApellido = apellido.Length >= 3 ? apellido[..3] : apellido;

            string correo = $"{prefNombre}{prefApellido}{numRandom}@laempresa.com";
            return new Email(correo);
        }
    }

}
