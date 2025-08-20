using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioCriaturas.Models;

namespace InventarioCriaturas.Services
{
    internal class Inventario
    {
        private readonly List<Criatura> criaturas = new();

        public void Adicionar(Criatura criatura)
        {
            criaturas.Add(criatura);
        }

        public Criatura? CriaturaMaisPoderosa()
        {
            if (!criaturas.Any()) return null;

            return criaturas.OrderByDescending(c => c.ForcaTotal()).First();
        }
    }
}