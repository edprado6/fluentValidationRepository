using FluentValidation.Attributes;
using FluentValidation.WebApi.Validators;
using System;

namespace FluentValidation.WebApi.ViewModels.Entities
{
    [Validator(typeof(UsuarioValidator))]
    public class UsuarioViewModel : EntidadeBase
    {
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
            if(nascimento != null) {

                Idade = (DateTime.Now.Subtract(Convert.ToDateTime(nascimento)).Days/365);
            }

            Nascimento = nascimento;
        }

        public UsuarioViewModel()
        {

        }
    }
}