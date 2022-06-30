using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class SenhaTagController
    {
        public static SenhaTag InserirSenhaTag(
            int SenhaId,
            int TagId
        )
        {
            SenhaController.GetSenha(SenhaId);
            TagController.GetTag(TagId);

            return new SenhaTag(SenhaId, TagId);
        }
        public static SenhaTag GetSenhaTag(
            int SenhaId,
            int TagId
        )
        {
            return SenhaTag.GetSenhaTag(SenhaId, TagId);
        }

        public static IEnumerable<SenhaTag> GetSenhaTags()  
        {
            return SenhaTag.GetSenhaTags();
        }

        public static SenhaTag GetById(
            int Id
        )  
        {
            return SenhaTag.GetById(Id);
        }

        public static void ExcluirSenhaTag(
            int Id
        )
        {
            try
            {
                SenhaTag senhaTag = SenhaTag.GetById(Id);
                SenhaTag.RemoverSenhaTag(senhaTag);
            }
            catch
            {
                throw new Exception(
                    "Não foi possível excluir a Tag de Senha "
                    + "pois o ID não existe"
                );
            }
        }

    }
}