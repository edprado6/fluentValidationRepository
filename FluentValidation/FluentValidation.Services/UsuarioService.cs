
using FluentValidation.Data.Repositories;
using FluentValidation.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FluentValidation.Services
{
    public class UsuarioService 
    {
        public UsuarioRepository _usuarioRepository;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
        }

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
            var result = _usuarioRepository.GetByCPF(cpf);

            return result;
        }

        public Usuario GetByEmail(string email)
        {
            var result = _usuarioRepository.GetByEmail(email);

            return result;
        }

        public Usuario GetById(long id)
        {
            var result = _usuarioRepository.GetById(id);

            return result;
        }

        public Usuario Insert(Usuario usuario)
        {
            var result = _usuarioRepository.Insert(usuario);

            return result;
        }

        public Usuario Update(long id, Usuario usuario)
        {
            var existeUsuario = GetById(id);

            if ((existeUsuario != null) && (usuario != null)) {

                usuario.Id = id;

                var result = _usuarioRepository.Update(usuario);

                return result;
            }

            return existeUsuario;
        }

        public bool CPFExistente(string cpf) {

            var usuario = GetByCPF(cpf);

            return (usuario == null);
        }
    }
}
