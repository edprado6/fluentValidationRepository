using FluentValidation.Api.ViewModels;
using FluentValidation.Infra;
using FluentValidation.Infra.Helpers.Validators;
using FluentValidation.Services;
using FluentValidation.Validators;
using System;
using System.Text.RegularExpressions;
using System.Web;

namespace FluentValidation.Api.Validators
{
    public class UsuarioValidator : BaseValidator<UsuarioViewModel>
    {
        private UsuarioService _usuarioService;

        public UsuarioValidator()
        {            
            var action = HttpContext.Current.Request.HttpMethod.ToString();

            _usuarioService = new UsuarioService();

            RuleFor(x => x.Nome).Length(5, 50).NotEmpty();                              // Validacao de tamanho do campo (de acordo com o banco e regra de validacao)
            
            When(x => (action == "POST"), () =>                                         // Regra aplicada somente na criação
            {
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
            });

            When(x => (action == "PUT"), () =>                                          // Regra aplicada somente na edição
            {
                RuleFor(x => x.Email)
                    .Must(ForcaCampoVazio).WithMessage(Resource.ForcaCampoVazio);       // Caso algum valor seja enviado é exido mensagem

                RuleFor(x => x.CPF)
                   .Must(ForcaCampoVazio).WithMessage(Resource.ForcaCampoVazio);
            });

            RuleFor(x => x.Senha).NotEmpty()                                            // Senha obrigatoria
                .Matches(new Regex("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$")) // Regex para validação de senha forte
                .WithMessage(Resource.SenhaValidacao);

            RuleFor(x => x.ConfirmacaoSenha)            
                .Equal(x => x.Senha).WithMessage(Resource.ConfirmacaoSenha);            // Forca senha e confirmacao de senha terem o mesmo valor

            RuleFor(x => x.Nascimento).NotEmpty();                                      // Data de nascimento obrigatoria

            RuleFor(x => x.Ativo).NotEmpty();                                          // Ativo obrigatorio
            
            RuleFor(x => x.Idade)
                .Must(ValidaIdade).WithMessage(Resource.ValidaIdade);                   // Validacao aplicada a um valor calculado a partir da data de nascimento
            
        }
        
        /// <summary>
        /// Valida uma idade a partir da data de nascimento.
        /// </summary>
        /// <param name="rootObject"></param>
        /// <param name="idade"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool ValidaIdade(UsuarioViewModel rootObject, int idade, PropertyValidatorContext context) {

            idade = (DateTime.Now.Subtract(Convert.ToDateTime(rootObject.Nascimento)).Days/365);
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
        /// <param name="rootObject"></param>
        /// <param name="cpf"></param>
        /// <param name="context"></param>
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

        /// <summary>
        /// Usado para campos do tipo string que nao serao atualizados.
        /// </summary>
        /// <param name="campo"></param>
        /// <returns></returns>
        private bool ForcaCampoVazio(UsuarioViewModel rootObject, string campo, PropertyValidatorContext context) {

            if (string.IsNullOrEmpty(campo) || (campo == null)) {

                return true;
            }

            context.MessageFormatter.AppendArgument("campo", "");
            return false;
        }
    }
}