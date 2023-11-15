using ApiVetShop.Models;

namespace ApiVetShop.IRepository
{
    public interface IUsersRepository
    {
        public Task<Details> SelectUser(int id);
        public Boolean VerifyUser(string email, string password);
    }
}
