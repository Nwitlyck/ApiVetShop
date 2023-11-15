using APICurso.IDapper;
using ApiVetShop.IRepository;
using ApiVetShop.Models;
using Dapper;

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
                    return await conn.QueryAsync<Cliente>("list_details");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}