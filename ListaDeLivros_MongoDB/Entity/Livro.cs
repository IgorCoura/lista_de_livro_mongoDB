using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_MongoDB.Entity
{
    public class Livro
    {
        public Livro(string titulo, DateTime dataPublicacao, int paginas, string idioma, List<string> autores, string descricao, List<Avaliacao> avaliacao)
        {
            Titulo = titulo;
            DataPublicacao = dataPublicacao;
            Paginas = paginas;
            Idioma = idioma;
            Autores = autores;
            Descricao = descricao;
            Avaliacao = avaliacao;
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int Paginas { get; set; }
        public string Idioma { get; set; }
        public List<String> Autores { get; set; }
        public String Descricao { get; set; }
        public List<Avaliacao> Avaliacao { get; set; }

    }
}
