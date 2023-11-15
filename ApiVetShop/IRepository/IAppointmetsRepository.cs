using ApiVetShop.Models;
using System.Data.SqlTypes;

namespace ApiVetShop.IRepository
{
    public interface IAppointmetsRepository
    {
        public Task<IEnumerable<Appoiments>> ListAppointmets();
        public Task<int> UpdateAppointment(Appoiments appoiment);
    }
}
