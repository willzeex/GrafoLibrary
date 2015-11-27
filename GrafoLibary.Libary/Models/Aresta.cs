using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLibary.Libary.Models
{
    public class Aresta
    {
        public Vertice VerticeOrigem { get; set; }
        public Vertice VerticeDestino { get; set; }
        public bool Direcionado { get; set; }
        public Double Peso { get; set; }
    }
}
