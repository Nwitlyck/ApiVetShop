using ApiVetShop.Models;

namespace ApiVetShop.IBLL
{
    public interface IAppoinmentsBLL
    {
        public Task<ResponseListAppointments> ListAppointments(int userId);
        public Task<ResponseAppointments> UpdateAppointment(Appoiments appoiment);
    }
}
