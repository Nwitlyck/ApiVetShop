using ApiVetShop.Models;

namespace ApiVetShop.IBLL
{
    public interface IUsersBLL
    {
        public Task<ResponseUsers> SelectUser(string email);
        public Task<ResponseVerify> VerifyUser(LogIn logIn);
    }
}
