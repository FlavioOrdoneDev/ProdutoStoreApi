﻿using FluentValidation.Results;
using ProdutoStoreApi.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProdutoStoreApi.Dominio.Entidades
{
    public class Categoria
    {
        public Categoria(){}
        public Categoria(string nome, string descricao, bool ativo = true){
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }

        public bool IsValid()
        {
            CategoriaValidador categoriaConsistente = new CategoriaValidador();
            ResultadoValidacao = categoriaConsistente.Validate(this);

            return ResultadoValidacao.IsValid;
        }

        [NotMapped]
        public ValidationResult ResultadoValidacao { get; set; }
    }
}
