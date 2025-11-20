using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.Utilidades
{
    public static class PasswordGenerator
    {
            public static string Generar(int length = 8)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

                return new string(Enumerable.Range(0, length)
                    .Select(_ => chars[Random.Shared.Next(chars.Length)])
                    .ToArray());
            }
        }
    }

