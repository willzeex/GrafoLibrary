using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoLibary.Libary.Models
{
    public class Resposta
    {
        public Resposta()
        {
            this.Linhas = new List<Linha>();
        }
        public string Titulo { get; set; }
        public List<Linha> Linhas { get; set; }
    }
}
