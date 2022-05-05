using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text;

namespace Controllers
{
    public class UsuarioController
    {
        public static Usuario InserirUsuario(
            string Nome,
            string Email,
            string Senha
        )
        {
            Regex rx = new Regex("^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+(\\.[a-z]+)?$");

            if (String.IsNullOrEmpty(Email) || !rx.IsMatch(Email))
            {
                throw new Exception("Email inválido");
            }
            if (String.IsNullOrEmpty(Email)) 
            {
                throw new Exception("Email é obrigatório");
            }
            if (String.IsNullOrEmpty(Senha)) 
            {
                throw new Exception("Senha é obrigatório");
            }
            if (Senha.Length < 8) 
            {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }

            return new Usuario(Nome, Email, Senha);
        }

        public static Usuario AlterarUsuario(
            int Id,
            string Nome,
            string Email,
            string Senha
        )
        {
            Usuario usuario = Usuario.GetUsuario(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                usuario.Nome = Nome;
            }
            Regex rx = new Regex("^[a-z0-9.]+@[a-z0-9]+\\.[a-z]+(\\.[a-z]+)?$");
            if (String.IsNullOrEmpty(Email) || !rx.IsMatch(Email))
            {
                throw new Exception("Email inválido");
            }
            if (!String.IsNullOrEmpty(Email)) 
            {
                usuario.Email = Email;
            }
            if (!String.IsNullOrEmpty(Senha)) 
            {
                usuario.Senha = Senha;
            }
            if (Senha.Length < 8) 
            {
                throw new Exception("A senha deve ter no mínimo 8 caracteres.");
            }
            return usuario;
        }
        public static Usuario ExcluirUsuario(
            int Id
        )
        {
            Usuario usuario = Usuario.GetUsuario(Id);
            Models.Usuario.RemoverUsuario(usuario);
            return usuario;
        }
        public static IEnumerable<Usuario> GetUsuarios()
        {
            return Usuario.GetUsuarios();
        }

        public static Usuario GetUsuario(
            int Id
        )
        {
            Usuario usuario = (
                from Usuario in Usuario.GetUsuarios()
                    where Usuario.Id == Id
                    select Usuario
            ).First();
            
            if (usuario == null)
            {
                throw new Exception("Usuario não encontrada");
            }

            return usuario;
        }
        public static void Auth(string Email, string Senha) {
            try {
                Usuario.Auth(Email, Senha);
            }
            catch
            {
                throw new Exception("Email ou senha inválido");
            }
        }
    }
}