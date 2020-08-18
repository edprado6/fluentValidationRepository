using FluentValidation.Data.IRepositories;
using FluentValidation.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FluentValidation.Services
{
    public class UsuarioService : IUsuarioService
    {
        public IUsuarioRepository _usuarioRepository { private get; set; }

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
            var result = _usuarioRepository.GetById(id);

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
