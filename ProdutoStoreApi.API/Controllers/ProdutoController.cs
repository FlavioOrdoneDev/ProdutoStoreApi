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
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppServico _produtoAppServico;

        public ProdutoController(IProdutoAppServico produtoAppServico)
        {
            _produtoAppServico = produtoAppServico;
        }

        [Route("produto")]
        [HttpGet]
        public IEnumerable<ProdutoViewModel> Get()
        {
            var produtos = _produtoAppServico.ObterTodos();
            return produtos;
        }

        [Route("produto/{id}")]
        [HttpGet]
        public ProdutoViewModel Get(int id)
        {
            var produtoViewModel = _produtoAppServico.ObterPorId(id);
            return produtoViewModel;
        }        

        [Route("produto")]
        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            _produtoAppServico.Adicionar(produto);
            return Ok(new { success = true, data = produto });
        }

        [Route("produto")]
        [HttpPut]
        public ActionResult Put([FromBody] Produto produto)
        {
            _produtoAppServico.Atualizar(produto);
            return Ok(new { success = true, data = produto });
        }

        [Route("produto")]
        [HttpDelete]
        public Produto Delete([FromBody] Produto produto)
        {
            _produtoAppServico.Remover(produto);
            return produto;
        }
    }
}