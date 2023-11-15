using APICurso.IDapper;
using ApiVetShop.IRepository;
using ApiVetShop.Models;
using Dapper;
using System.Data;

namespace ApiVetShop.Repository
{
    public class UserRepository : IUsersRepository
    {
        private readonly IDapperContext _context;
        public UserRepository(IDapperContext context)
        {
            _context = context;
        }
        public Task<Details> SelectUser(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@id", id, DbType.Int64, ParameterDirection.Input);
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QuerySingleOrDefaultAsync<Users>("select_user", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> VerifyUser(string email, string password)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();

                param.Add("@id", email, DbType.String, ParameterDirection.Input);
                param.Add("@id", password, DbType.String, ParameterDirection.Input);
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QuerySingleOrDefaultAsync<Cliente>("verify_user", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
