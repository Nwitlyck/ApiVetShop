using ApiVetShop.Helpers;
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
        public async Task<Users> SelectUser(string email)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@vEmail", email, DbType.String, ParameterDirection.Input);
                using (var conn = _context.CrearConexion()){
                    return await conn.QuerySingleOrDefaultAsync<Users>("[vetShop].[dbo].[select_user]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> VerifyUser(string email, string password)
        {
            try
            {
                var param = new DynamicParameters();

                param.Add("@vEmail", email, DbType.String, ParameterDirection.Input);
                param.Add("@vPassworld", password, DbType.String, ParameterDirection.Input);
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QuerySingleOrDefaultAsync<Boolean>("[vetShop].[dbo].[verify_user]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
