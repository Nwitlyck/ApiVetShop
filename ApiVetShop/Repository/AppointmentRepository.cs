using APICurso.IDapper;
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
        public Task<IEnumerable<Appoiments>> ListAppointmets()
        {
            try
            {
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QueryAsync<Appoiments>("list_appointments");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int> UpdateAppointment(Appoiments appoiment)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", appoiment.Id, DbType.Int64, ParameterDirection.Input);
                param.Add("@user_name", appoiment.UserName, DbType.String, ParameterDirection.Input);
                param.Add("@customer_name", appoiment.CustomerName, DbType.String, ParameterDirection.Input);
                param.Add("@unit_name", appoiment.UnitName, DbType.String, ParameterDirection.Input);
                param.Add("@site_name", appoiment.SiteName, DbType.String, ParameterDirection.Input);
                param.Add("@asistant_name", appoiment.AsistantName, DbType.String, ParameterDirection.Input);
                param.Add("@date_time", appoiment.DateTime, DbType.DateTime, ParameterDirection.Input);
                param.Add("@adress", appoiment.Adress, DbType.String, ParameterDirection.Input);
                param.Add("@canton", appoiment.Canton, DbType.String, ParameterDirection.Input);
                param.Add("@province", appoiment.Province, DbType.String, ParameterDirection.Input);
                param.Add("@description", appoiment.Description, DbType.String, ParameterDirection.Input);
                param.Add("@state", appoiment.State, DbType.String, ParameterDirection.Input);
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QuerySingleOrDefaultAsync<Appoiments>("update_appointment", param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
