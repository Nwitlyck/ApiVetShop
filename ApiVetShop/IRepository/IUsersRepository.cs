using ApiVetShop.Models;

namespace ApiVetShop.IRepository
{
    public interface IUsersRepository
    {
        public Task<Users> SelectUser(int id);
        public Task<Boolean> VerifyUser(string email, string password);
    }
}
