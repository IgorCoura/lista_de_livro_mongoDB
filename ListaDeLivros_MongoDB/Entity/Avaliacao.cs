using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_MongoDB.Entity
{
    public class Avaliacao
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Nota { get; set; }
        public string Resenha { get; set; }
    }
}
