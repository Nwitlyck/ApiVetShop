using ApiVetShop.IDapper;
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
        public Task<Users> SelectUser(int id)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@vId", id, DbType.Int64, ParameterDirection.Input);
                using (var conn = _context.CrearConexion()){
                    return conn.QuerySingleOrDefaultAsync<Users>("select_user", param, commandType: CommandType.StoredProcedure);
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
                var param = new DynamicParameters();

                param.Add("@vEmail", email, DbType.String, ParameterDirection.Input);
                param.Add("@vPassworld", password, DbType.String, ParameterDirection.Input);
                using (var conn = _context.CrearConexion())
                {
                    return conn.QuerySingleOrDefaultAsync<Boolean>("verify_user", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
