using FluentValidation.Data.Repositories;
using FluentValidation.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FluentValidation.Services
{
    public class UsuarioService : IUsuarioService
    {
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetByCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public Usuario GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(long id)
        {
            var repository = new UsuarioRepository();
            var result = repository.GetById(id);

            return result;
        }

        public Usuario Insert(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
