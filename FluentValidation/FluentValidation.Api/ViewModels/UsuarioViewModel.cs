using FluentValidation.Api.Validators;
using FluentValidation.Attributes;
using System;

namespace FluentValidation.Api.ViewModels
{
    [Validator(typeof(UsuarioValidator))]
    public class UsuarioViewModel
    {
        /// <summary>
        /// Não informar (inserido automaticamente)
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Obrigatorio (deve ter entre 5 e 50 caracteres)
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obrigatorio (maximo de 50 caracteres)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obrigatorio (Informar 11 caracteres/somente numeros)        
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Obrigatorio (entre 8 e 15 caracteres, pelo menos um número, pelo menos uma letra maiúscula e pelo menos uma letra minúscula)
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Obrigatorio
        /// </summary>
        public DateTime Nascimento { get; set; }

        /// <summary>
        /// Obrigatorio
        /// </summary>
        public bool Ativo { get; set; }
               
        /// <summary>
        /// Não informar (inserido automaticamente)
        /// </summary>
        public DateTime Cadastro { get; set; }

        /// <summary>
        /// Não informar (inserido automaticamente)
        /// </summary>
        public DateTime UltimaAtualizacao { get; set; }

        /// <summary>
        /// Campo obrigatorio (deve ser igual a senha)
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