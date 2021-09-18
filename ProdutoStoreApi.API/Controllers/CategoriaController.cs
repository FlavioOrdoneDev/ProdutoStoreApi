using Microsoft.AspNetCore.Mvc;
using ProdutoStoreApi.AplicacaoServico.AppModels;
using ProdutoStoreApi.AplicacaoServico.AppServicos;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoStoreApi.API.Controllers
{
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppServico _categoriaAppServico;

        public CategoriaController(ICategoriaAppServico categoriaAppServico)
        {
            _categoriaAppServico = categoriaAppServico;
        }

        [Route("categoria")]
        [HttpGet]
        public IEnumerable<CategoriaViewModel> Get()
        {
            var categorias = _categoriaAppServico.ObterTodas();
            return categorias;
        }

        [Route("categoria/{id}")]
        [HttpGet]
        public CategoriaViewModel Get(int id)
        {
            var categoriaViewModel = _categoriaAppServico.ObterPorId(id);
            return categoriaViewModel;
        }        

        [Route("categoria")]
        [HttpPost]
        public ActionResult Post([FromBody]Categoria categoria)
        {            
           _categoriaAppServico.Adicionar(categoria);

            return Ok(new { success = true, data = categoria });
        }

        [Route("categoria")]
        [HttpPut]
        public Categoria Put([FromBody] Categoria categoria)
        {
            _categoriaAppServico.Atualizar(categoria);
            return categoria;
        }

        [Route("categoria")]
        [HttpDelete]
        public Categoria Delete([FromBody] Categoria categoria)
        {
            _categoriaAppServico.Remover(categoria);
            return categoria;
        }
    }
}