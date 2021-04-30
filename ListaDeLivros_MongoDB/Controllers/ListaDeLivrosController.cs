using Biblioteca_MongoDB.Data;
using Biblioteca_MongoDB.Entity;
using Biblioteca_MongoDB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeLivrosController : Controller
    {
        private readonly Repository<Livro> _repository;

        public ListaDeLivrosController(Repository<Livro> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create([FromBody]LivroCreateModel livroModel)
        {
            try
            {
                var livro = new Livro(livroModel.Titulo, livroModel.DataPublicacao, livroModel.Paginas, livroModel.Idioma, livroModel.Autores, livroModel.Descricao, livroModel.Avaliacao);
                _repository.Insert(livro);
                return Created("Criado com sucesso", livro);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Edit(string id, LivroCreateModel livroModel)
        {
            try
            {
                var livro = new Livro(livroModel.Titulo, livroModel.DataPublicacao, livroModel.Paginas, livroModel.Idioma, livroModel.Autores, livroModel.Descricao, livroModel.Avaliacao);
                livro.Id = id;
                _repository.Update(Builders<Livro>.Filter.Eq(x => x.Id, id), livro);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                _repository.Delete(Builders<Livro>.Filter.Eq(x=>x.Id, id));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var livros = _repository.SelectAll(Builders<Livro>.Filter.Empty);
                return Ok(livros);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Get")]
        public IActionResult Get(string id)
        {
            try
            {
                var livro = _repository.Select(Builders<Livro>.Filter.Eq(x => x.Id, id));
                return Ok(livro);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
