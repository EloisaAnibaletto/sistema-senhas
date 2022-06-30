using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class TagController
    {
        public static Tag InserirTag(
            string Descricao
        )
        {
            if (String.IsNullOrEmpty(Descricao)) 
            {
                throw new Exception("Número é obrigatório");
            }

            return new Tag(Descricao);
        }

        public static Tag AlterarTag(
            int Id,
            string Descricao
        )
        {
            Tag tag = Tag.GetTag(Id);

            if (!String.IsNullOrEmpty(Descricao)) 
            {
                tag.Descricao = Descricao;
            }
            Models.Tag.AlterarTag(Id, Descricao);
            
            return tag;
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

        public static Tag GetTag(
            int Id
        )
        {
            Tag tag = (
                from Tag in Tag.GetTags()
                    where Tag.Id == Id
                    select Tag
            ).First();
            
            if (tag == null)
            {
                throw new Exception("Tag não encontrada");
            }

            return tag;
        }
    }
}