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
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ProdutoStoreContexto _contexto;

        public CategoriaRepositorio(ProdutoStoreContexto contexto)
        {
            _contexto = contexto;
        }

        public Categoria Adicionar(Categoria obj)
        {
            var result = _contexto.Categorias.Add(obj).Entity;
            Salvar();
            return result;
        }

        public Categoria Atualizar(Categoria obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
            Salvar();
            return obj;
        }       

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public Categoria ObterPorId(int id)
        {
            return _contexto.Categorias.Include(x => x.Produtos).AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Categoria> ObterTodas()
        {
            return _contexto.Categorias.Include(x => x.Produtos);
        }        

        public Categoria Remover(Categoria obj)
        {
            _contexto.Categorias.Remove(obj);
            Salvar();
            return obj;
        }

        public void Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}
