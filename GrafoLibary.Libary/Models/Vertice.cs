using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLibary.Libary.Models
{
    public class Vertice
    {
        public Vertice()
        {
            this.ArestasChegando = new List<Aresta>();
            this.ArestasSaindo = new List<Aresta>();
        }
        public string Nome { get; set; }
        public List<Aresta> ArestasSaindo { get; set; }
        public List<Aresta> ArestasChegando { get; set; }
    }
}
