using FluentValidation.Domain.Entities;
using System.Collections.Generic;

namespace FluentValidation.Services
{
    public interface IUsuarioService
    {
        Usuario Insert(Usuario usuario);

        Usuario Update(Usuario usuario);

        Usuario GetById(long id);

        List<Usuario> GetAll();

        void Delete(long id);

        Usuario GetByEmail(string email);

        Usuario GetByCPF(string cpf);
    }
}
