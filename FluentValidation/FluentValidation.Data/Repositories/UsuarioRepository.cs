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
            string sql = $@"INSERT INTO Usuario (Nome,Email,CPF,Senha,Nascimento,Ativo,Excluido,Cadastro)
                            OUTPUT INSERTED.*
                            VALUES (@Nome, @Email, @CPF, @Senha, @Nascimento, @Ativo, 0, GETDATE());";

            var result = _conn.QuerySingle<Usuario>(sql, usuario);

            return result;
        }

        public Usuario Update(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario GetByEmail(string email)
        {
            string sql = $@"SELECT * FROM Usuario WHERE Email = @email;";

            var result = _conn.Query<Usuario>(sql, new { email }).FirstOrDefault();

            return result;
        }
        
        public Usuario GetByCPF(string cpf)
        {
            string sql = $@"SELECT * FROM Usuario WHERE CPF = @cpf;";

            var result = _conn.Query<Usuario>(sql, new { cpf }).FirstOrDefault();

            return result;
        }               
    }
}
