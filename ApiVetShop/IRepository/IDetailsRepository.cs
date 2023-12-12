using ApiVetShop.Models;

namespace ApiVetShop.IRepository
{
    public interface IDetailsRepository
    {
        public Task<IEnumerable<Details>> ListDetails();
    }
}
