using ApiVetShop.Models;

namespace ApiVetShop.Models
{
    public class ResponseAppointments
    {
        public Appoiments Appointment { get; set; } = new Appoiments();
        public ResponseModel Errors { get; set; } = new ResponseModel();
    }
}
