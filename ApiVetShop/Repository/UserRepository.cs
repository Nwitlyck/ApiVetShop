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
        private readonly EncrypAPICall _encrypAPICall;
        public UserRepository(IDapperContext context, EncrypAPICall encrypAPICall)
        {
            _context = context;
            _encrypAPICall = encrypAPICall;
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
                var encrypted = await _encrypAPICall.GetEncrypt(password);

                param.Add("@vEmail", email, DbType.String, ParameterDirection.Input);
                param.Add("@vPassworld", encrypted.encryp, DbType.String, ParameterDirection.Input);
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
