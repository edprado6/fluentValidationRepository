using Dapper;
using FluentValidation.Data.IRepositories;
using FluentValidation.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FluentValidation.Data.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            throw new System.NotImplementedException();
        }
       
        public Usuario GetById(long id)
        {
            string sql = $@"SELECT * FROM Usuario WHERE Id = @id;";

            var result = _conn.Query<Usuario>(sql, new { id }).FirstOrDefault();

            return result;
        }

        public Usuario Insert(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Update(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
        
        public Usuario GetByCPF(string cpf)
        {
            throw new System.NotImplementedException();
        }               
    }
}
