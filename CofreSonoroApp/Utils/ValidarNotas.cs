using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CofreSonoroApp.Utils
{
    internal static class Validador
    {
        public static bool ValidarNotas(string[] notas)
        {
            return notas.All(n => !string.IsNullOrWhiteSpace(n));
        }
    }
}