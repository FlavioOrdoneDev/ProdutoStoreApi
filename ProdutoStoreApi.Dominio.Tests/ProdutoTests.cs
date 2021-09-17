using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdutoStoreApi.Dominio.Tests
{
    [TestClass]
    public class ProdutoTests
    {
        #region ProdutoNome

        [TestMethod]
        public void ProdutoNome_DeveAceitarNomeDaCategoriaComMaisDeTresCaracteresEMenosDeCem()
        {
            var produto = ObterProduto("Pen drive");

            var teste = produto;

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

            var penDrive = new Produto("Pen drive", "Pen drive 8gb", true, false, 1);
            var nomeNulo = new Produto(null, "Produto com nome nulo", false, false, 1);
            var produtoDoisCaracteres = new Produto("aa", "Produto com nome menor que três caracteres", true, true, 1);
            var produtoMaisDeCemCaracteres = new Produto("NomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteres", "Produto com mais de cem caracteres", true, true, 1);

            var descricaoNula = new Produto("DescricaoNula", null, true, true, 1);
            var produtoDescricaoDoisCaracteres = new Produto("ProdutoDescricaoDoisCaracteres", "aa", true, true, 1);
            var descricaoProdutoMuitoGrande = new Produto("DescricaoProdutoMuitoGrande", "NomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteresNomeProdutoComMaisDeCEmCaracteres", true, true, 1);

            var ativoFalse = new Produto("AtivoFalse", "Produto com campo Ativo false", false, false, 1);
            var ativoTrue = new Produto("AtivoTrue", "Produto com campo Ativo true por default", true, true, 1);

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
