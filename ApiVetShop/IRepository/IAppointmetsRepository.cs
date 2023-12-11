using ApiVetShop.Models;
using System.Data.SqlTypes;

namespace ApiVetShop.IRepository
{
    public interface IAppointmetsRepository
    {
        public Task<IEnumerable<Appoiments>> ListAppointmets(string useremail);
        public Task<int> UpdateAppointment(AppoinmentUpdate appoiment);
    }
}
