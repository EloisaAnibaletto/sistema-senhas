using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;
using Repository;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using System.Text;

namespace Controllers
{
    public class SenhaController
    {
        public static Senha InserirSenha(
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            if (String.IsNullOrEmpty(Nome)) 
            {
                throw new Exception("Nome é obrigatório");
            }
            if (CategoriaId < 0) 
            {
                throw new Exception("Categoria é obrigatório");
            }
            if (String.IsNullOrEmpty(Url)) 
            {
                throw new Exception("Url é obrigatório");
            }
            Regex rx = new Regex(
                "https?:\\/\\/(?:www\\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|www\\.[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|https?:\\/\\/(?:www\\.|(?!www))"
                + "[a-zA-Z0-9]+\\.[^\\s]{2,}|www\\.[a-zA-Z0-9]+\\.[^\\s]{2,}"
            );
            if (String.IsNullOrEmpty(Url) || !rx.IsMatch(Url))
            {
                throw new Exception("A url é inválida.");
            }
            if (String.IsNullOrEmpty(Usuario)) 
            {
                throw new Exception("Usuario é obrigatório");
            }
            if (String.IsNullOrEmpty(SenhaEncrypt)) 
            {
                throw new Exception("Senha é obrigatório");
            }
            if (SenhaEncrypt.Length < 8) 
            {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }

            return new Senha(Nome, CategoriaId, Url, Usuario, SenhaEncrypt, Procedimento);
        }

        public static Senha AlterarSenha(
            int Id,
            string Nome,
            int CategoriaId,
            string Url,
            string Usuario,
            string SenhaEncrypt,
            string Procedimento
        )
        {
            Senha senha = Senha.GetSenha(Id);
            CategoriaController.GetCategoria(CategoriaId);

            if (!String.IsNullOrEmpty(Nome))
            {
                senha.Nome = Nome;
            }
            Regex rx = new Regex(
                "https?:\\/\\/(?:www\\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|www\\.[a-zA-Z0-9][a-zA-Z0-9-]+"
                + "[a-zA-Z0-9]\\.[^\\s]{2,}|https?:\\/\\/(?:www\\.|(?!www))"
                + "[a-zA-Z0-9]+\\.[^\\s]{2,}|www\\.[a-zA-Z0-9]+\\.[^\\s]{2,}"
            );
            if (!String.IsNullOrEmpty(Url)) 
            {
                senha.Url = Url;
            }
            if (!String.IsNullOrEmpty(Usuario)) 
            {
                senha.Usuario = Usuario;
            }
            if (SenhaEncrypt.Length < 8)
            {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }
            if (!String.IsNullOrEmpty(Procedimento)) 
            {
                senha.Procedimento = Procedimento;
            }
            return senha;
        }
        public static Senha ExcluirSenha(
            int Id
        )
        {
            Senha senha = Senha.GetSenha(Id);
            Models.Senha.RemoverSenha(senha);
            return senha;
        }
        public static IEnumerable<Senha> GetSenhas()
        {
            return Senha.GetSenhas();
        }

        public static Senha GetSenha(
            int Id
        )
        {
            Senha senha = (
                from Senha in Senha.GetSenhas()
                    where Senha.Id == Id
                    select Senha
            ).First();
            
            if (senha == null)
            {
                throw new Exception("Senha não encontrada");
            }

            return senha;
        }
    }
}