using ProdutoStoreApi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdutoStoreApi.Dominio.Servicos.Interfaces
{
    public interface IProdutoServico
    {
        Produto Adicionar(Produto produto);
        Produto Atualizar(Produto produto);
        Produto ObterPorId(int id);
        IEnumerable<Produto> ObterTodos();
        Produto Remover(Produto produto);
    }
}
