using Biblioteca_MongoDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_MongoDB.Model
{
    public class LivroCreateModel
    {
        public LivroCreateModel(string titulo, DateTime dataPublicacao, int paginas, string idioma, List<string> autores, string descricao, List<Avaliacao> avaliacao)
        {
            Titulo = titulo;
            DataPublicacao = dataPublicacao;
            Paginas = paginas;
            Idioma = idioma;
            Autores = autores;
            Descricao = descricao;
            Avaliacao = avaliacao;
        }

        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int Paginas { get; set; }
        public string Idioma { get; set; }
        public List<String> Autores { get; set; }
        public String Descricao { get; set; }
        public List<Avaliacao> Avaliacao { get; set; }
    }
}
