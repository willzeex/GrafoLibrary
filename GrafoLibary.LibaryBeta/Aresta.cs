using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLibary.LibaryBeta
{
    public class Aresta
    {
        public string Id { get; set; }
        public Vertice Origem { get; set; }
        public Vertice Destino { get; set; }
        public double Peso { get; set; }
    }
}
