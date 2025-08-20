using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CofreSonoroApp.Services
{
    internal class CofreSonoro
    {
        private readonly string[] senha;

        public CofreSonoro(string[] senha)
        {
            if (senha.Length != 4)
                throw new ArgumentException("A senha deve conter exatamente 4 notas.");

            this.senha = senha;
        }

        public bool TentarAbrir(string[] tentativa)
        {
            if (tentativa.Length != 4) return false;

            for (int i = 0; i < 4; i++)
            {
                if (!tentativa[i].Equals(senha[i], StringComparison.OrdinalIgnoreCase))
                    return false;
            }
            return true;
        }
    }
}