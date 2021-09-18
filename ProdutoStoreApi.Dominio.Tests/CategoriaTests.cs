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
        #region Adicionar

        
        [TestMethod]
        public void CategoriaAdicionar_DeveAceitarNomeDaCategoriaComMaisDeTresCaracteresEMenosDeCem()
        {
            var categoria = ObterCategoria("Eletrônico");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoria)).Returns(categoria);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoria);

            Assert.IsTrue(resultado.IsValid());           
        }

        [TestMethod]
        public void CategoriaAdicionar_NaoDeveAceitarNomeDaCategoriaNulo()
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
        public void CategoriaAdicionar_NaoDeveAceitarNomeDaCategoriaComMenosDeTresCaracteres()
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
        public void CategoriaAdicionar_NaoDeveAceitarNomeDaCategoriaComMaisDeCemCaracteres()
        {
            var categoriaMaisDeCemCaracteres = ObterCategoria("NomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteres");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaMaisDeCemCaracteres)).Returns(categoriaMaisDeCemCaracteres);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoriaMaisDeCemCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaAdicionar_NaoDeveAceitarDescricaoDaCategoriaNula()
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
        public void CategoriaAdicionar_NaoDeveAceitarDescricaoDaCategoriaComMenosDeTresCaracteres()
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
        public void CategoriaAdicionar_NaoDeveAceitarDescricaoDaCategoriaComMaisDeDuzentosECinquentaCaracteres()
        {
            var descricaoCategoriaMuitoGrande = ObterCategoria("DescricaoCategoriaMuitoGrande");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(descricaoCategoriaMuitoGrande)).Returns(descricaoCategoriaMuitoGrande);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(descricaoCategoriaMuitoGrande);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }


        [TestMethod]
        public void CategoriaAdicionar_AoCriarUmaCategoriaNovaOCampoAtivoDeveSerTrueComoDefault()
        {
            var ativoTrueDefault = ObterCategoria("AtivoTrueDefault");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(ativoTrueDefault)).Returns(ativoTrueDefault);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(ativoTrueDefault);

            Assert.IsTrue(resultado.Ativo);
        }

        [TestMethod]
        public void CategoriaAdicionar_DeveAceitarCampoAtivoDaCategoriaIgualATrue()
        {
            var categoria = ObterCategoria("Eletrônico");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoria)).Returns(categoria);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(categoria);
            resultado.SetarAtivo(true);

            Assert.IsTrue(resultado.Ativo);
        }

        [TestMethod]
        public void CategoriaAdicionar_DeveAceitarCampoAtivoDaCategoriaIgualAFalse()
        {
            var ativoFalse = ObterCategoria("AtivoFalse");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Adicionar(ativoFalse)).Returns(ativoFalse);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Adicionar(ativoFalse);
            resultado.SetarAtivo(false);

            Assert.IsFalse(resultado.Ativo);
        }


        #endregion        


        #region Atualizar

        [TestMethod]
        public void CategoriaAtualizar_DeveAceitarAtualizarNomeDaCategoriaComMaisDeTresCaracteresEMenosDeCem()
        {
            var categoria = ObterCategoria("Eletrônico");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Atualizar(categoria)).Returns(categoria);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            categoria.SetarNome("Eletrônico Novo");

            var resultado = categoriaServico.Atualizar(categoria);

            Assert.IsTrue(resultado.IsValid());
        }

        [TestMethod]
        public void CategoriaAtualizar_NaoDeveAceitarAtualizarNomeDaCategoriaNulo()
        {
            var categoriaNomeNulo = ObterCategoria(null);

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Atualizar(categoriaNomeNulo)).Returns(categoriaNomeNulo);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Atualizar(categoriaNomeNulo);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("NotNullValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaAtualizar_NaoDeveAceitarAtualizarNomeDaCategoriaComMenosDeTresCaracteres()
        {
            var categoriaDoisCaracteres = ObterCategoria("aa");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Atualizar(categoriaDoisCaracteres)).Returns(categoriaDoisCaracteres);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Atualizar(categoriaDoisCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MinimumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaAtualizar_NaoDeveAceitarAtualizarNomeDaCategoriaComMaisDeCemCaracteres()
        {
            var categoriaMaisDeCemCaracteres = ObterCategoria("NomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteres");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Atualizar(categoriaMaisDeCemCaracteres)).Returns(categoriaMaisDeCemCaracteres);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Atualizar(categoriaMaisDeCemCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaAtualizar_NaoDeveAceitarAtualizarDescricaoDaCategoriaNula()
        {
            var categoriaDescricaoNula = ObterCategoria("DescricaoNula");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Atualizar(categoriaDescricaoNula)).Returns(categoriaDescricaoNula);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Atualizar(categoriaDescricaoNula);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("NotNullValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaAtualizar_NaoDeveAceitarAtualizarDescricaoDaCategoriaComMenosDeTresCaracteres()
        {
            var categoriaDescricaoDoisCaracteres = ObterCategoria("CategoriaDescricaoDoisCaracteres");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Atualizar(categoriaDescricaoDoisCaracteres)).Returns(categoriaDescricaoDoisCaracteres);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Atualizar(categoriaDescricaoDoisCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MinimumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void CategoriaAtualizar_NaoDeveAceitarAtualizarDescricaoDaCategoriaComMaisDeDuzentosECinquentaCaracteres()
        {
            var descricaoCategoriaMuitoGrande = ObterCategoria("DescricaoCategoriaMuitoGrande");

            var repositorio = new Mock<ICategoriaRepositorio>();
            repositorio.Setup(s => s.Atualizar(descricaoCategoriaMuitoGrande)).Returns(descricaoCategoriaMuitoGrande);

            var categoriaServico = new CategoriaServico(repositorio.Object);

            var resultado = categoriaServico.Atualizar(descricaoCategoriaMuitoGrande);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }  
        

        #endregion


        #region Configuracoes


        public Categoria ObterCategoria(string nome)
        {
            var categorias = new List<Categoria>();

            var eletronico = new Categoria("Eletrônico", "Eletrodomésticos");
            eletronico.SetarAtivo(false);
            var nomeNulo = new Categoria(null, "Categoria com nome nulo");
            var categoriaDoisCaracteres = new Categoria("aa", "Categoria com nome menor que três caracteres");
            var categoriaMaisDeCemCaracteres = new Categoria("NomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteres", "Categoria com mais de cem caracteres");            
            
            var descricaoNula = new Categoria("DescricaoNula", null);
            var categoriaDescricaoDoisCaracteres = new Categoria("CategoriaDescricaoDoisCaracteres", "aa");
            var descricaoCategoriaMuitoGrande = new Categoria("DescricaoCategoriaMuitoGrande", "NomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteresNomeCategoriaComMaisDeCEmCaracteres");

            var ativoFalse = new Categoria("AtivoFalse", "Categoria com campo Ativo false");
            var ativoTrueDefault = new Categoria("AtivoTrueDefault", "Categoria com campo Ativo true por default");

            categorias.Add(eletronico);
            categorias.Add(nomeNulo);
            categorias.Add(categoriaDoisCaracteres);
            categorias.Add(categoriaMaisDeCemCaracteres);

            categorias.Add(descricaoNula);
            categorias.Add(categoriaDescricaoDoisCaracteres);
            categorias.Add(descricaoCategoriaMuitoGrande);

            categorias.Add(ativoFalse);
            categorias.Add(ativoTrueDefault);

            return categorias.Where(r => r.Nome == nome).FirstOrDefault();
        }

        #endregion
    }
}
