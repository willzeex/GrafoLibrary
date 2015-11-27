using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLibary.Libary.Models
{
    public class Grafo
    {
        public Grafo()
        {
            this.Vertices = new List<Vertice>();
            this.Arestas = new List<Aresta>();
            this.Comandos = new List<Comando>();
        }
        public List<Vertice> Vertices { get; set; }
        public List<Aresta> Arestas { get; set; }
        public List<Comando> Comandos { get; set; }
        public bool Direcionado { get; set; }
        public bool Peso { get; set; }
    }
}
