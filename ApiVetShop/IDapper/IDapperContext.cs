using System.Data;

namespace ApiVetShop.IDapper
{
    public interface IDapperContext
    {
        public IDbConnection CrearConexion();
    }
}
