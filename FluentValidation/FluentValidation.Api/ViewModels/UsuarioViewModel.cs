using FluentValidation.Api.Validators;
using FluentValidation.Attributes;
using System;

namespace FluentValidation.Api.ViewModels
{
    [Validator(typeof(UsuarioValidator))]
    public class UsuarioViewModel
    {
        public long Id { get; set; }

        public bool Ativo { get; set; }
               
        public DateTime Cadastro { get; set; }

        public DateTime UltimaAtualizacao { get; set; }
               
        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string Senha { get; set; }

        public DateTime Nascimento { get; set; }

        /// <summary>
        /// Campo obrigatorio
        /// </summary>
        public string ConfirmacaoSenha { get; set; }

        /// <summary>
        /// Campo calculado (nao informar)
        /// </summary>
        public int Idade { get; set; }

        public UsuarioViewModel(DateTime nascimento)
        {
            if (nascimento != null)
            {

                Idade = (DateTime.Now.Subtract(Convert.ToDateTime(nascimento)).Days / 365);
            }

            Nascimento = nascimento;
        }

        public UsuarioViewModel()
        {

        }
    }
}