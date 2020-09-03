using FluentValidation.Api.ViewModels;
using FluentValidation.Infra;
using FluentValidation.Infra.Helpers.Validators;
using FluentValidation.Services;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FluentValidation.Api.Validators
{
    public class UsuarioValidator : BaseValidator<UsuarioViewModel>
    {
        private UsuarioService _usuarioService;

        public UsuarioValidator()
        {
            _usuarioService = new UsuarioService();

            RuleFor(x => x.Nome)
                .Length(5, 50)                                                         // Validacao de tamanho do campo (de acordo com o banco e regra de validacao)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Resource.EmailInformar)                         // E-mail obrigatorio
                .MaximumLength(50).WithMessage(Resource.EmailTamanho)                   // Maximo de 50 caracteres (de acordo com o banco)
                .EmailAddress().WithMessage(Resource.EmailInvalido)                     // Formato de e-mail inválido
                .Must(ValidaEmailExistente).WithMessage(Resource.EmailCadastrado);      // Depende de consulta ao banco

            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage(Resource.CPFInformado)                          // CPF obrigatorio
                .Length(11, 11).WithMessage(Resource.CPFTamanho)                        // Limitacao de tamanho (de acordo com banco e regra de validacao)
                .Must(ValidateCPF.IsCpf).WithMessage(Resource.CPFInvalido)              // Nao validado de acordo com algoritmo de validacao
                .Must(ValidaCPFExistente).WithMessage(Resource.CPFCadastrado);          // Depende de consulta ao banco

            RuleFor(x => x.Senha)
                .NotEmpty()                                                             // Senha obrigatoria
                .Matches(new Regex("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$")) // Regex para validação de senha forte
                .WithMessage(Resource.SenhaValidacao);

            RuleFor(x => x.ConfirmacaoSenha)            
                .Equal(x => x.Senha).WithMessage(Resource.ConfirmacaoSenha);            // Forca senha e confirmacao de senha terem o mesmo valor

            RuleFor(x => x.Nascimento)
                .NotEmpty();                                                            // Data de nascimento obrigatoria

            RuleFor(x => x.Ativo)                                                       // Ativo obrigatorio
               .NotEmpty(); 

            RuleFor(x => x.Idade)
                .Must(ValidaIdade).WithMessage(Resource.ValidaIdade);                   // Validacao aplicada a um valor calculado a partir da data de nascimento
            
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
        
        /// <summary>
        /// Verifica se já existe o CPF informado
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public bool ValidaCPFExistente(UsuarioViewModel rootObject, string cpf, PropertyValidatorContext context)
        {            
            var usuario = _usuarioService.GetByCPF(cpf);

            return (usuario == null) ? true : false;
        }

        /// <summary>
        /// Verifica se já existe o Email informado
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidaEmailExistente(UsuarioViewModel rootObject, string email, PropertyValidatorContext context)
        {
            var usuario = _usuarioService.GetByEmail(email);

            return (usuario == null) ? true : false;
        }
    }
}