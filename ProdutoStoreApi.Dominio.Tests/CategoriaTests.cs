using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutoStoreApi.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace ProdutoStoreApi.Dominio.Tests
{
    [TestClass]
    public class CategoriaTests
    {
        [TestMethod]
        public void Categoria_NaoDeveAceitarNomeDaCategoriaNulo()
        {
            var categoria = ObterCategoria(null);

            Assert.IsNotNull(categoria.Nome);
        }

        #region Configuracoes


        public Categoria ObterCategoria(string nome)
        {
            var categorias = new List<Categoria>();

            var eletronico = new Categoria("Eletr�nico", "Eletrodom�sticos");
            var informatica = new Categoria("Inform�tica", "Produtos para Inform�tica");
            var celulares = new Categoria("Celulares", "Aparelhos e acess�rios");
            var moda = new Categoria("Moda", "Artigos para vestu�rio em geral");
            var livros = new Categoria("Livros", "Livros");            
            var nomeNulo = new Categoria(null, "Categoria com nome nulo");            

            categorias.Add(eletronico);
            categorias.Add(informatica);
            categorias.Add(celulares);
            categorias.Add(moda);
            categorias.Add(livros);
            categorias.Add(nomeNulo);

            return categorias.Where(r => r.Nome == nome).FirstOrDefault();
        }

        #endregion
    }
}
