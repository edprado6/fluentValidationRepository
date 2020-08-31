using FluentValidation.WebApi.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentValidation.WebApi.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioViewModel>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Nome).Length(0, 50);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Idade).GreaterThan(18);
        }
    }
}