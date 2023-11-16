using ApiVetShop.IBLL;
using ApiVetShop.IRepository;
using ApiVetShop.Models;

namespace ApiVetShop.BLL
{
    public class AppointmentsBLL : IAppoinmentsBLL
    {
        private IAppointmetsRepository _appointmetsRepository;
        public AppointmentsBLL(IAppointmetsRepository appointmetsRepository) 
        {
            _appointmetsRepository = appointmetsRepository;
        }
        public async Task<ResponseListAppointments> ListAppointments(int userId)
        {
            try
            {
                var listAppoinments = await _appointmetsRepository.ListAppointmets(userId);

                var responseListAppoinments = new ResponseListAppointments();
                responseListAppoinments.Appointmets = listAppoinments.ToList();

                var responseModel = new ResponseModel();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Lista de citas devuelta con éxito";

                responseListAppoinments.Errors = responseModel;
                
                return responseListAppoinments;

            }catch(Exception)
            {
                throw;
            }
        }

        public async Task<ResponseAppointments> UpdateAppointment(Appoiments appoiment)
        {
            try
            {
                var idAppoinment = await _appointmetsRepository.UpdateAppointment(appoiment);

                var responseAppoinments = new ResponseAppointments();
                responseAppoinments.Appointment.Id = idAppoinment;

                var responseModel = new ResponseModel();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Cita actualizada con éxito";

                responseAppoinments.Errors = responseModel;

                return responseAppoinments;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
