using ApiVetShop.Models;

namespace ApiVetShop.IBLL
{
    public interface IAppoinmentsBLL
    {
        public Task<ResponseListAppointments> ListAppointments(int userId);
        public Task<ResponseAppointmentsUpdate> UpdateAppointment(AppoinmentUpdate appoinmentUpdate);
    }
}
