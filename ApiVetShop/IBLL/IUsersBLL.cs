using ApiVetShop.Models;

namespace ApiVetShop.IBLL
{
    public interface IUsersBLL
    {
        public Task<ResponseUsers> SelectUser(int id);
        public Task<ResponseVerify> VerifyUser(string email, string password);
    }
}
