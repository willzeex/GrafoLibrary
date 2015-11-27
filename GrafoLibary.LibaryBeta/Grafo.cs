using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLibary.LibaryBeta
{
    public class Grafo
    {
        public List<Vertice> Vertices;
        public List<Aresta> Arestas;
        public Grafo(List<Vertice> vertices, List<Aresta> arestas)
        {
            Arestas = arestas;
            Vertices = vertices;
        }
    }
}
