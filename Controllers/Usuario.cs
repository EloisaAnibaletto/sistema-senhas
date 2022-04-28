using System;
using System.Collections.Generic;
using System.Linq;
using Models;
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
        public static Tag ExcluirTag(
            int Id
        )
        {
            Tag tag = Tag.GetTag(Id);
            Models.Tag.RemoverTag(tag);
            return tag;
        }
        public static IEnumerable<Tag> GetTags()
        {
            return Tag.GetTags();
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
    }
}