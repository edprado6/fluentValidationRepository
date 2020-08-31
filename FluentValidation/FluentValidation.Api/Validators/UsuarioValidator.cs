using FluentValidation.Api.ViewModels;
using FluentValidation.Validators;
using System;

namespace FluentValidation.Api.Validators
{

    public class UsuarioValidator : AbstractValidator<UsuarioViewModel>
    {
        public UsuarioValidator()
        {            
            RuleFor(x => x.Nome).Length(0, 50);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo 'Email' deve ser informado.")
                .EmailAddress().WithMessage("O valor informado no campo 'Email' não é um e-mail válido.");
            
            RuleFor(x => x.ConfirmacaoSenha)
                .Equal(x => x.Senha).WithMessage("Os campos 'Senha' e 'ConfirmacaoSenha' devem ser iguais.");
                        
            RuleFor(x => x.Idade)
                .Must((ValidaIdade)).WithMessage("O usuário deverá ter '{PropertyName}' superior a {idadeMinima} anos.");
            
        }

        /// <summary>
        /// Valida uma idade a partir da data de nascimento.
        /// </summary>
        /// <param name="rootObject"></param>
        /// <param name="list"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool ValidaIdade(UsuarioViewModel rootObject, int list, PropertyValidatorContext context) {

            var idade = (DateTime.Now.Subtract(Convert.ToDateTime(rootObject.Nascimento)).Days/365);
            if (idade < 18)
            {
                context.MessageFormatter.AppendArgument("idadeMinima", 18);
                return false;
            }
            return true;
        }
    }
}