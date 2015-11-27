using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLibary.Libary.Models
{
    public class Comando
    {
        public Comando()
        {
            this.Vertices = new List<Vertice>();
        }
        public string Nome { get; set; }
        public List<Vertice> Vertices { get; set; }
    }
}
