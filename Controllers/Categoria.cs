using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repository;

namespace Controllers
{
    public class CategoriaController
    {
        public static Categoria InserirCategoria(
            string Nome,
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Nome)) {
                throw new Exception("Nome é obrigatório");
            }

            return new Categoria(Nome, Descricao);
        }

        public static Categoria AlterarCategoria(
            int Id,
            string Nome,
            string Descricao
        )
        {
            Categoria categoria = Categoria.GetCategoria(Id);

            if (!String.IsNullOrEmpty(Nome)) {
                categoria.Nome = Nome;
            }
            if (!String.IsNullOrEmpty(Descricao)) {
                categoria.Descricao = Descricao;
            }
            //categoria.Nome = Nome;
            Models.Categoria.AlterarCategoria(Id, Nome, Descricao);

            return categoria;
        }
        public static Categoria ExcluirCategoria(
            int Id
        )
        {
            Categoria categoria = Categoria.GetCategoria(Id);
            Models.Categoria.RemoverCategoria(categoria);
            return categoria;
        }
        public static IEnumerable<Categoria> GetCategorias()
        {
            return Categoria.GetCategorias();
        }

        public static Categoria GetCategoria(
            int Id
        )
        {
            Categoria categoria = (
                from Categoria in Categoria.GetCategorias()
                    where Categoria.Id == Id
                    select Categoria
            ).First();
            
            if (categoria == null)
            {
                throw new Exception("Categoria não encontrada");
            }

            return categoria;
        }
    }
}