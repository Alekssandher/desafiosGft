using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioCriaturas.Models
{
    internal abstract class Criatura
    {
        public string Nome { get; set; }
        public string Poder { get; set; }
        public int ForcaBase { get; set; }

        protected Criatura(string nome, string poder, int forcaBase)
        {
            Nome = nome;
            Poder = poder;
            ForcaBase = forcaBase;
        }

        public abstract int ForcaTotal();
    }
}