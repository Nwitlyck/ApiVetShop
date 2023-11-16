using ApiVetShop.Models;

namespace ApiVetShop.IBLL
{
    public interface IDetailsBLL
    {
        public Task<ResponseListDetails> ListDetails();
    }
}
