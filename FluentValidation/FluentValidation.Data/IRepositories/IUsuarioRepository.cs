using FluentValidation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentValidation.Data.IRepositories
{
    public interface IUsuarioRepository
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
