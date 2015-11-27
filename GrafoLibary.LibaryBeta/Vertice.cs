using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLibary.LibaryBeta
{
    public class Vertice
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public bool EhTerminal { get; set; }
        public Vertice(string id, string nome, bool ehTerminal = false)
        {
            Id = id;
            Nome = nome;
            EhTerminal = ehTerminal;
        }
    }
}
