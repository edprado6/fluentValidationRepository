using FluentValidation.Api.ViewModels;
using FluentValidation.Infra.Helpers.Validators;
using FluentValidation.Services;
using FluentValidation.Validators;
using System;

namespace FluentValidation.Api.Validators
{

    public class UsuarioValidator : BaseValidator<UsuarioViewModel>
    {
        public IUsuarioService _usuarioService;

        public UsuarioValidator()
        {            
            RuleFor(x => x.Nome).Length(0, 50);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo 'Email' deve ser informado.")
                .EmailAddress().WithMessage("O valor informado no campo 'Email' não é um e-mail válido.");

            RuleFor(x => x.CPF)
                .Length(11, 11).WithMessage("O campo 'CPF' deve possuir 11 caracteres.")                
                .Must(ValidateCPF.IsCpf).WithMessage("O numero informado não é um 'CPF' válido")
                .Must(CPFExistente).WithMessage("Já existe 'CPF' cadastrado.")
                ;

            RuleFor(x => x.ConfirmacaoSenha)
                .Equal(x => x.Senha).WithMessage("Os campos 'Senha' e 'ConfirmacaoSenha' devem ser iguais.");
                        
            RuleFor(x => x.Idade)
                .Must(ValidaIdade).WithMessage("O usuário deverá ter '{PropertyName}' superior a {idadeMinimaUsuario} anos.");
            
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
            if (idade < _idadeMinimaUsuario)
            {
                context.MessageFormatter.AppendArgument("idadeMinimaUsuario", _idadeMinimaUsuario);
                return false;
            }
            return true;
        }
        
        public bool CPFExistente(string cpf)
        {
            _usuarioService = new UsuarioService();
            var usuario = _usuarioService.GetByCPF(cpf);

            return (usuario == null) ? true : false;
        }
    }
}