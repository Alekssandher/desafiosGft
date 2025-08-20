using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioCriaturas.Models
{
    internal class Dragao : Criatura
    {
        public Dragao(string nome, string poder, int forcaBase)
            : base(nome, poder, forcaBase) { }

        public override int ForcaTotal()
        {
            return ForcaBase + 50;
        }
    }
}