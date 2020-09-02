using System;

namespace FluentValidation.Domain.Entities
{
    public class Usuario
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string Senha { get; set; }

        public DateTime Nascimento { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }

        public DateTime Cadastro { get; set; }

        public DateTime UltimaAtualizacao { get; set; }

        public DateTime Exclusao { get; set; }
    }
}
