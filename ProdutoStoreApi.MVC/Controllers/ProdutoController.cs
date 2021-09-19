using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProdutoStoreApi.AplicacaoServico.AppModels;
using ProdutoStoreApi.AplicacaoServico.AppServicos;
using ProdutoStoreApi.Dominio.Entidades;

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
            ViewBag.IdCategoria = new SelectList(_categoriaAppServico.ObterTodas(), "IdCategoria", "Nome", "");

            var produto = new ProdutoViewModel();
            produto.Produtos = _produtoAppServico.ObterTodos();
            ModelState.Clear();

            return View(produto);
        }

        [HttpPost]
        public ActionResult Adicionar(Produto produto)
        {
            ViewBag.IdCategoria = new SelectList(_categoriaAppServico.ObterTodas(), "IdCategoria", "Nome", "");

            var produtoViewModel = _produtoAppServico.Adicionar(produto);

            if (produto.ResultadoValidacao.Errors.Count > 0)
            {
                produtoViewModel.ResultadoValidacao = produto.ResultadoValidacao;
            }

            produtoViewModel.Produtos = _produtoAppServico.ObterTodos();

            return RedirectToAction("Index");
        }

        public ActionResult buscarProdutos()
        {
            var produtos = _produtoAppServico.ObterTodos();

            return PartialView("_buscarProdutos", produtos);
        }

        public ActionResult Editar(int id)
        {
            ViewBag.IdCategoria = new SelectList(_categoriaAppServico.ObterTodas(), "IdCategoria", "Nome", "");

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
            var produtoViewModel = new ProdutoViewModel();
            _produtoAppServico.Atualizar(produto);

            if (produto.ResultadoValidacao.Errors.Count > 0)
            {
                produtoViewModel.ResultadoValidacao = produto.ResultadoValidacao;
                ViewBag.IdCategoria = new SelectList(_categoriaAppServico.ObterTodas(), "IdCategoria", "Nome", "");

                return View("Editar", produtoViewModel);
            }

            produtoViewModel.Produtos = _produtoAppServico.ObterTodos();

            return RedirectToAction("Index");
        }

        public ActionResult Deletar(int id)
        {            
            var produto = _produtoAppServico.ObterPorId(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        public ActionResult Deletar(Produto produto)
        {
            if (ModelState.IsValid)
                _produtoAppServico.Remover(produto);
            else
                RedirectToAction("Index");

            var produtoViewModel = new ProdutoViewModel();
            produtoViewModel.Produtos = _produtoAppServico.ObterTodos();

            return RedirectToAction("Index");
        }
    }
}

