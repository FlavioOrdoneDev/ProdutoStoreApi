using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProdutoStoreApi.AplicacaoServico.AppModels;
using ProdutoStoreApi.AplicacaoServico.AppServicos;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoStoreApi.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        
        private readonly IProdutoAppServico _produtoAppServico;
        private readonly ICategoriaAppServico _categoriaAppServico;

        public ProdutoController(IProdutoAppServico produtoAppServico, ICategoriaAppServico categoriaAppServico)
        {
            _produtoAppServico = produtoAppServico;
            _categoriaAppServico = categoriaAppServico;
        }        

        public ActionResult Index()
        {
            var categorias = _categoriaAppServico.ObterTodas();
            ViewBag.IdCategoria = new SelectList(categorias, "IdCategoria", "Nome", "");

            var produtos = _produtoAppServico.ObterTodos();
            var produto = new ProdutoViewModel(produtos);

            return View(produto);
        }

        [HttpPost]
        public ActionResult Adicionar(Produto produto)
        {
            var categorias = _categoriaAppServico.ObterTodas();
            ViewBag.IdCategoria = new SelectList(categorias, "IdCategoria", "Nome", "");           

            _produtoAppServico.Adicionar(produto);

            var produtos = _produtoAppServico.ObterTodos();
            var produtoViewModel = new ProdutoViewModel(produtos);            

            return View("Index", produtoViewModel);
        }

        public ActionResult buscarProdutos()
        {
            var produtos = _produtoAppServico.ObterTodos();

            return PartialView("_buscarProdutos", produtos);
        }

        public ActionResult Editar(int id)
        {
            var produto = _produtoAppServico.ObterPorId(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoAppServico.Atualizar(produto);
            }
            else
            {
                RedirectToAction("Index");
            }

            return View("ndex");
        }

        public ActionResult Detalhes(int id)
        {
            var produto = _produtoAppServico.ObterPorId(id);
            return View(produto);
        }
    }
}

