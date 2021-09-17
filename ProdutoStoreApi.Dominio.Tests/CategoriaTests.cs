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
        #region CategoriaNome

        [TestMethod]
        public void CategoriaNome_DeveAceitarNomeDaCategoriaComMaisDeTresCaracteresEMenosDeCem()
        {
            var categoria = ObterCategoria("Eletrônico");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoria)).Returns(categoria);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoria);

            Assert.IsTrue(resultado.IsValid());           
        }

        [TestMethod]
        public void CategoriaNome_NaoDeveAceitarNomeDaCategoriaNulo()
        {
            var categoriaNomeNulo = ObterCategoria(null);

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaNomeNulo)).Returns(categoriaNomeNulo);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoriaNomeNulo);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("NotNullValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaNome_NaoDeveAceitarNomeDaCategoriaComMenosDeTresCaracteres()
        {
            var categoriaDoisCaracteres = ObterCategoria("aa");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaDoisCaracteres)).Returns(categoriaDoisCaracteres);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoriaDoisCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MinimumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaNome_NaoDeveAceitarNomeDaCategoriaComMaisDeCemCaracteres()
        {
            var categoriaMaisDeCemCaracteres = ObterCategoria("NomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteres");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaMaisDeCemCaracteres)).Returns(categoriaMaisDeCemCaracteres);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoriaMaisDeCemCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }


        #endregion



        #region CategoriaDescricao

        [TestMethod]
        public void CategoriaDescricao_DeveAceitarNomeDaCategoriaComMaisDeTresCaracteresEMenosDeDuzentosECinquenta()
        {
            var categoria = ObterCategoria("Eletrônico");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoria)).Returns(categoria);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoria);

            Assert.IsTrue(resultado.IsValid());
        }

        [TestMethod]
        public void CategoriaDescricao_NaoDeveAceitarDescricaoDaCategoriaNula()
        {
            var categoriaDescricaoNula = ObterCategoria("DescricaoNula");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaDescricaoNula)).Returns(categoriaDescricaoNula);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoriaDescricaoNula);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("NotNullValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaDescricao_NaoDeveAceitarDescricaoDaCategoriaComMenosDeTresCaracteres()
        {
            var categoriaDescricaoDoisCaracteres = ObterCategoria("CategoriaDescricaoDoisCaracteres");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaDescricaoDoisCaracteres)).Returns(categoriaDescricaoDoisCaracteres);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoriaDescricaoDoisCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MinimumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaDescricao_NaoDeveAceitarDescricaoDaCategoriaComMaisDeDuzentosECinquentaCaracteres()
        {
            var descricaoCategoriaMuitoGrande = ObterCategoria("DescricaoCategoriaMuitoGrande");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(descricaoCategoriaMuitoGrande)).Returns(descricaoCategoriaMuitoGrande);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(descricaoCategoriaMuitoGrande);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }


        #endregion









        #region Configuracoes


        public Categoria ObterCategoria(string nome)
        {
            var categorias = new List<Categoria>();

            var eletronico = new Categoria("Eletrônico", "Eletrodomésticos");                       
            var nomeNulo = new Categoria(null, "Categoria com nome nulo");
            var categoriaDoisCaracteres = new Categoria("aa", "Categoria com nome menor que três caracteres");
            var categoriaMaisDeCemCaracteres = new Categoria("NomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteres", "Categoria com mais de cem caracteres");            
            
            var descricaoNula = new Categoria("DescricaoNula", null);
            var categoriaDescricaoDoisCaracteres = new Categoria("CategoriaDescricaoDoisCaracteres", "aa");
            var descricaoCategoriaMuitoGrande = new Categoria("DescricaoCategoriaMuitoGrande", "NomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteres");

            categorias.Add(eletronico);
            categorias.Add(nomeNulo);
            categorias.Add(categoriaDoisCaracteres);
            categorias.Add(categoriaMaisDeCemCaracteres);

            categorias.Add(descricaoNula);
            categorias.Add(categoriaDescricaoDoisCaracteres);
            categorias.Add(descricaoCategoriaMuitoGrande);

            return categorias.Where(r => r.Nome == nome).FirstOrDefault();
        }

        #endregion
    }
}
