using ApiVetShop.Models;

namespace ApiVetShop.IRepository
{
    public interface IUsersRepository
    {
        public Task<Details> SelectUser(int id);
        public Task<Boolean> VerifyUser(string email, string password);
    }
}
