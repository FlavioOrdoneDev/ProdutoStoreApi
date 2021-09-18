using ProdutoStoreApi.AplicacaoServico.AppModels;
using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.AplicacaoServico.AppServicos
{
    public interface IProdutoAppServico
    {
        ProdutoViewModel Adicionar(Produto produto);
        ProdutoViewModel Atualizar(Produto produto);
        ProdutoViewModel ObterPorId(int id);
        IEnumerable<ProdutoViewModel> ObterTodos();
        ProdutoViewModel Remover(Produto produto);
    }
}
