using System;

namespace FluentValidation.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string Senha { get; set; }

        public DateTime Nascimento { get; set; }
    }
}
