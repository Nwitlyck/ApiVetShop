using ApiVetShop.IDapper;
using ApiVetShop.IRepository;
using ApiVetShop.Models;
using Dapper;
using System.Data;

namespace ApiVetShop.Repository
{
    public class AppointmentRepository : IAppointmetsRepository
    {
        private readonly IDapperContext _context;
        public AppointmentRepository(IDapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Appoiments>> ListAppointmets(string useremail)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@vEmail", useremail, DbType.String, ParameterDirection.Input);
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QueryAsync<Appoiments>("[vetShop].[dbo].[list_appointments]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAppointment(AppoinmentUpdate appoinmentUpdate)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@vId", appoinmentUpdate.Id, DbType.Int64, ParameterDirection.Input);
                param.Add("@vDescription", appoinmentUpdate.Description, DbType.String, ParameterDirection.Input);
                param.Add("@vState", appoinmentUpdate.State, DbType.Int64, ParameterDirection.Input);
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QuerySingleOrDefaultAsync<int>("[vetShop].[dbo].[update_appointment]", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
