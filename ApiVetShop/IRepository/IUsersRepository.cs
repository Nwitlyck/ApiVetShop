using ApiVetShop.Models;

namespace ApiVetShop.IRepository
{
    public interface IUsersRepository
    {
        public Task<Users> SelectUser(string email);
        public Task<Boolean> VerifyUser(string email, string password);
    }
}
