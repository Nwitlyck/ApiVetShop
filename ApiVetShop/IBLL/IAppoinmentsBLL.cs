using ApiVetShop.Models;

namespace ApiVetShop.IBLL
{
    public interface IAppoinmentsBLL
    {
        public Task<ResponseListAppointments> ListAppointments(string useremail);
        public Task<ResponseAppointmentsUpdate> UpdateAppointment(AppoinmentUpdate appoinmentUpdate);
    }
}
