using Microsoft.EntityFrameworkCore;
using ProdutoStoreApi.Dados.Contexto;
using ProdutoStoreApi.Dominio.Entidades;
using ProdutoStoreApi.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdutoStoreApi.Dados.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ProdutoStoreContexto _contexto;

        public ProdutoRepositorio(ProdutoStoreContexto contexto)
        {
            _contexto = contexto;
        }

        public Produto Adicionar(Produto obj)
        {
            var result = _contexto.Produtos.Add(obj).Entity;
            Salvar();
            return result;
        }

        public Produto Atualizar(Produto obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
            Salvar();
            return obj;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public Produto ObterPorId(int id)
        {
            return _contexto.Produtos.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _contexto.Produtos.Include(c => c.Categoria).AsNoTracking();
        }

        public Produto Remover(Produto obj)
        {
            _contexto.Produtos.Remove(obj);
            Salvar();
            return obj;
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}

