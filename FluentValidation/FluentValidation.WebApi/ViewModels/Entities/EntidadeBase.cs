using System;

namespace FluentValidation.WebApi.ViewModels.Entities
{
    public abstract class EntidadeBase
    {
        public long Id { get; set; }

        public bool Ativo { get; set; }

       //public bool Excluido { get; set; }

        public DateTime Cadastro { get; set; }

        public DateTime UltimaAtualizacao { get; set; }

        //public DateTime Exclusao { get; set; }
    }
}