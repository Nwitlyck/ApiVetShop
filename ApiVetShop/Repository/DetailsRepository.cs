using ApiVetShop.IDapper;
using ApiVetShop.IRepository;
using ApiVetShop.Models;
using Dapper;
using System.Data;

namespace ApiVetShop.Repository
{
    public class DetailsRepository : IDetailsRepository
    {
        private readonly IDapperContext _context;
        public DetailsRepository(IDapperContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<Details>> ListDetails()
        {
            try
            {
                using (var conn = _context.CrearConexion())
                {
                    return conn.QueryAsync<Details>("list_details", null, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}