using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafoLibary.UI.Models
{
    public class UploadFile
    {
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }
    }
}