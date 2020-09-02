namespace FluentValidation.Api.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected const int _idadeMinimaUsuario = 18;
    }
}