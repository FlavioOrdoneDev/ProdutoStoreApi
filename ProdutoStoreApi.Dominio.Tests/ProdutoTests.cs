using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProdutoStoreApi.Dominio.Entidades;
using ProdutoStoreApi.Dominio.Repositorios;
using ProdutoStoreApi.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdutoStoreApi.Dominio.Tests
{
    [TestClass]
    public class ProdutoTests
    {
        #region Adicionar

        [TestMethod]
        public void ProdutoAdicionar_DeveAceitarNomeComMaisDeTresCaracteresEMenosDeCem()
        {
            var produto = ObterProduto("Pen drive"); 

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(produto)).Returns(produto);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(produto);

            Assert.IsTrue(resultado.IsValid());
        }

        [TestMethod]
        public void ProdutoAdicionar_NaoDeveAceitarNomeNulo()
        {
            var produtoNomeNulo = ObterProduto(null);

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(produtoNomeNulo)).Returns(produtoNomeNulo);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(produtoNomeNulo);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("NotNullValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void ProdutoAdicionar_NaoDeveAceitarNomeComMenosDeTresCaracteres()
        {
            var produtoDoisCaracteres = ObterProduto("aa");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(produtoDoisCaracteres)).Returns(produtoDoisCaracteres);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(produtoDoisCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MinimumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void ProdutoAdicionar_NaoDeveAceitarNomeComMaisDeCemCaracteres()
        {
            var produtoMaisDeCemCaracteres = ObterProduto("NomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNome");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(produtoMaisDeCemCaracteres)).Returns(produtoMaisDeCemCaracteres);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(produtoMaisDeCemCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }


        [TestMethod]
        public void ProdutoAdicionar_DeveAceitarNomeComMaisDeTresCaracteresEMenosDeCemCaracteres()
        {
            var produto = ObterProduto("Pen drive");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(produto)).Returns(produto);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(produto);

            Assert.IsTrue(resultado.IsValid());
        }

        [TestMethod]
        public void ProdutoAdicionar_NaoDeveAceitarDescricaoNula()
        {
            var categoriaDescricaoNula = ObterProduto("DescricaoNula");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoriaDescricaoNula)).Returns(categoriaDescricaoNula);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(categoriaDescricaoNula);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("NotNullValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void ProdutoAdicionar_NaoDeveAceitarDescricaoComMenosDeTresCaracteres()
        {
            var produtoDescricaoDoisCaracteres = ObterProduto("ProdutoDescricaoDoisCaracteres");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(produtoDescricaoDoisCaracteres)).Returns(produtoDescricaoDoisCaracteres);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(produtoDescricaoDoisCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MinimumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void ProdutoAdicionar_NaoDeveAceitarDescricaoComMaisDeDuzentosECinquentaCaracteres()
        {
            var descricaoProdutoMuitoGrande = ObterProduto("DescricaoProdutoMuitoGrande");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(descricaoProdutoMuitoGrande)).Returns(descricaoProdutoMuitoGrande);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(descricaoProdutoMuitoGrande);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }


        [TestMethod]
        public void ProdutoAdicionar_DeveAceitarCampoAtivoIgualATrue()
        {
            var categoria = ObterProduto("Pen drive");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoria)).Returns(categoria);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(categoria);
            resultado.SetarAtivo(true);

            Assert.IsTrue(resultado.Ativo);
        }

        [TestMethod]
        public void ProdutoAdicionar_DeveAceitarCampoAtivoIgualAFalse()
        {
            var ativoFalse = ObterProduto("AtivoFalse");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(ativoFalse)).Returns(ativoFalse);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(ativoFalse);
            resultado.SetarAtivo(false);

            Assert.IsFalse(resultado.Ativo);
        }

        [TestMethod]
        public void ProdutoAdicionar_DeveAceitarCampoPerecivelIgualATrue()
        {
            var categoria = ObterProduto("Pen drive");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(categoria)).Returns(categoria);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(categoria);
            resultado.SetarAtivo(true);

            Assert.IsTrue(resultado.Ativo);
        }

        [TestMethod]
        public void ProdutoAdicionar_DeveAceitarCampoPerecivelIgualAFalse()
        {
            var ativoFalse = ObterProduto("AtivoFalse");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Adicionar(ativoFalse)).Returns(ativoFalse);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Adicionar(ativoFalse);
            resultado.SetarAtivo(false);

            Assert.IsFalse(resultado.Ativo);
        }

        #endregion



        #region Atualizar

        [TestMethod]
        public void ProdutoAtualizar_DeveAceitarAtualizarNomeComMaisDeTresCaracteresEMenosDeCem()
        {
            var produto = ObterProduto("Pen drive");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(produto)).Returns(produto);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(produto);

            Assert.IsTrue(resultado.IsValid());
        }

        [TestMethod]
        public void ProdutoAtualizar_NaoDeveAceitarAtualizarNomeNulo()
        {
            var produtoNomeNulo = ObterProduto(null);

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(produtoNomeNulo)).Returns(produtoNomeNulo);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(produtoNomeNulo);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("NotNullValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void ProdutoAtualizar_NaoDeveAceitarAtualizarNomeComMenosDeTresCaracteres()
        {
            var produtoDoisCaracteres = ObterProduto("aa");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(produtoDoisCaracteres)).Returns(produtoDoisCaracteres);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(produtoDoisCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MinimumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void ProdutoAtualizar_NaoDeveAceitarAtualizarNomeComMaisDeCemCaracteres()
        {
            var produtoMaisDeCemCaracteres = ObterProduto("NomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNome");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(produtoMaisDeCemCaracteres)).Returns(produtoMaisDeCemCaracteres);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(produtoMaisDeCemCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }


        [TestMethod]
        public void ProdutoAtualizar_DeveAceitarAtualizarNomeComMaisDeTresCaracteresEMenosDeCemCaracteres()
        {
            var produto = ObterProduto("Pen drive");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(produto)).Returns(produto);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(produto);

            Assert.IsTrue(resultado.IsValid());
        }

        [TestMethod]
        public void ProdutoAtualizar_NaoDeveAceitarAtualizarDescricaoNula()
        {
            var categoriaDescricaoNula = ObterProduto("DescricaoNula");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(categoriaDescricaoNula)).Returns(categoriaDescricaoNula);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(categoriaDescricaoNula);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("NotNullValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void ProdutoAtualizar_NaoDeveAceitarAtualizarDescricaoComMenosDeTresCaracteres()
        {
            var produtoDescricaoDoisCaracteres = ObterProduto("ProdutoDescricaoDoisCaracteres");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(produtoDescricaoDoisCaracteres)).Returns(produtoDescricaoDoisCaracteres);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(produtoDescricaoDoisCaracteres);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MinimumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }

        [TestMethod]
        public void ProdutoAtualizar_NaoDeveAceitarAtualizarDescricaoComMaisDeDuzentosECinquentaCaracteres()
        {
            var descricaoProdutoMuitoGrande = ObterProduto("DescricaoProdutoMuitoGrande");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(descricaoProdutoMuitoGrande)).Returns(descricaoProdutoMuitoGrande);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(descricaoProdutoMuitoGrande);

            Assert.IsFalse(resultado.IsValid());
            Assert.AreEqual("MaximumLengthValidator", resultado.ResultadoValidacao.Errors[0].ErrorCode);
        }


        [TestMethod]
        public void ProdutoAtualizar_DeveAceitarAtualizarCampoAtivoIgualATrue()
        {
            var categoria = ObterProduto("Pen drive");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(categoria)).Returns(categoria);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(categoria);
            resultado.SetarAtivo(true);

            Assert.IsTrue(resultado.Ativo);
        }

        [TestMethod]
        public void ProdutoAtualizar_DeveAceitarAtualizarCampoAtivoIgualAFalse()
        {
            var ativoFalse = ObterProduto("AtivoFalse");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(ativoFalse)).Returns(ativoFalse);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(ativoFalse);
            resultado.SetarAtivo(false);

            Assert.IsFalse(resultado.Ativo);
        }

        [TestMethod]
        public void ProdutoAtualizar_DeveAceitarAtualizarCampoPerecivelIgualATrue()
        {
            var categoria = ObterProduto("Pen drive");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(categoria)).Returns(categoria);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(categoria);
            resultado.SetarAtivo(true);

            Assert.IsTrue(resultado.Ativo);
        }

        [TestMethod]
        public void ProdutoAtualizar_DeveAceitarAtualizarCampoPerecivelIgualAFalse()
        {
            var ativoFalse = ObterProduto("AtivoFalse");

            var repositorio = new Mock<IProdutoRepositorio>();
            repositorio.Setup(s => s.Atualizar(ativoFalse)).Returns(ativoFalse);

            var produtoServico = new ProdutoServico(repositorio.Object);

            var resultado = produtoServico.Atualizar(ativoFalse);
            resultado.SetarAtivo(false);

            Assert.IsFalse(resultado.Ativo);
        }

        #endregion


        #region Configuracoes


        public Categoria ObterCategoria(string nome)
        {
            var categorias = new List<Categoria>();

            var eletronico = new Categoria("Eletrônico", "Eletrodomésticos");
            var informatica = new Categoria("Informática", "Produtos para Informática");
            var celulares = new Categoria("Celulares", "Aparelhos e acessórios");
            var moda = new Categoria("Moda", "Artigos para vestuário em geral");
            var livros = new Categoria("Livros", "Livros");
            var alimentos = new Categoria("Alimentos", "Alimentos em geral");

            categorias.Add(eletronico);
            categorias.Add(informatica);
            categorias.Add(celulares);
            categorias.Add(moda);
            categorias.Add(livros);
            categorias.Add(alimentos);            

            return categorias.Where(r => r.Nome == nome).FirstOrDefault();
        }

        public Produto ObterProduto(string nome)
        {
            var produtos = new List<Produto>();

            var penDrive = new Produto("Pen drive", "Pen drive 8gb", false, 1);
            var nomeNulo = new Produto(null, "Produto com nome nulo", false, 1);
            var produtoDoisCaracteres = new Produto("aa", "Produto com nome menor que três caracteres", true, 1);
            var produtoMaisDeCemCaracteres = new Produto("NomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNome", "Produto com mais de cem caracteres", true, 1);

            var descricaoNula = new Produto("DescricaoNula", null, true, 1);
            var produtoDescricaoDoisCaracteres = new Produto("ProdutoDescricaoDoisCaracteres", "aa", true, 1);
            var descricaoProdutoMuitoGrande = new Produto("DescricaoProdutoMuitoGrande", "NomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteres", true, 1);

            var ativoFalse = new Produto("AtivoFalse", "Produto com campo Ativo false", false, 1);
            var ativoTrue = new Produto("AtivoTrue", "Produto com campo Ativo true por default", true, 1);

            produtos.Add(penDrive);
            produtos.Add(nomeNulo);
            produtos.Add(produtoDoisCaracteres);
            produtos.Add(produtoMaisDeCemCaracteres);
            produtos.Add(descricaoNula);
            produtos.Add(produtoDescricaoDoisCaracteres);
            produtos.Add(descricaoProdutoMuitoGrande);
            produtos.Add(ativoFalse);
            produtos.Add(ativoTrue);

            return produtos.Where(p => p.Nome == nome).FirstOrDefault();
        }

        #endregion

    }
}
