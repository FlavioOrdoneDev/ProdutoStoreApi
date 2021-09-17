using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProdutoStoreApi.Dominio.Entidades;
using ProdutoStoreApi.Dominio.Repositorios;
using ProdutoStoreApi.Dominio.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace ProdutoStoreApi.Dominio.Tests
{
    [TestClass]
    public class CategoriaTests
    {
        [TestMethod]
        public void Categoria_DeveAceitarNomeDaCategoriaComMaisDeTresCaracteresEMenosDeCem()
        {
            var categoria = ObterCategoria("Eletrônico");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoria)).Returns(categoria);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoria);

            Assert.IsTrue(resultado.IsValid());
        }

        [TestMethod]
        public void Categoria_NaoDeveAceitarNomeDaCategoriaNulo()
        {
            var categoriaNomeNulo = ObterCategoria(null);

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaNomeNulo)).Returns(categoriaNomeNulo);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoriaNomeNulo);

            Assert.IsFalse(resultado.IsValid());
        }

        [TestMethod]
        public void Categoria_NaoDeveAceitarNomeDaCategoriaComMenosDeTresCaracteres()
        {
            var categoriaDoisCaracteres = ObterCategoria("aa");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaDoisCaracteres)).Returns(categoriaDoisCaracteres);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoriaDoisCaracteres);

            Assert.IsFalse(resultado.IsValid());
        }

        [TestMethod]
        public void Categoria_NaoDeveAceitarNomeDaCategoriaComMaisDeCemCaracteres()
        {
            var categoriaMaisDeCemCaracteres = ObterCategoria("NomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteres");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaMaisDeCemCaracteres)).Returns(categoriaMaisDeCemCaracteres);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoriaMaisDeCemCaracteres);

            Assert.IsFalse(resultado.IsValid());
        }












        #region Configuracoes


        public Categoria ObterCategoria(string nome)
        {
            var categorias = new List<Categoria>();

            var eletronico = new Categoria("Eletrônico", "Eletrodomésticos");                       
            var nomeNulo = new Categoria(null, "Categoria com nome nulo");
            var categoriaDoisCaracteres = new Categoria("aa", "Categoria com nome menor que três caracteres");
            var categoriaMaisDeCemCaracteres = new Categoria("NomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteres", "Categoria com mais de cem caracteres");            

            categorias.Add(eletronico);
            categorias.Add(nomeNulo);
            categorias.Add(categoriaDoisCaracteres);
            categorias.Add(categoriaMaisDeCemCaracteres);

            return categorias.Where(r => r.Nome == nome).FirstOrDefault();
        }

        #endregion
    }
}
