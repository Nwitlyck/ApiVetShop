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
        public async Task<IEnumerable<Details>> ListDetails()
        {
            try
            {
                using (var conn = _context.CrearConexion())
                {
                    return await conn.QueryAsync<Details>("[vetShop].[dbo].[list_details]", null, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}