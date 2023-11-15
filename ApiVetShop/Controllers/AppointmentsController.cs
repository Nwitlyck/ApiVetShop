using APICurso.BLL;
using APICurso.IBLL;
using APICurso.Models;
using ApiVetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiVetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsBLL _citasBLL;
        public AppointmentsController(IAppointmentsBLL citasBLL)
        {
            _citasBLL = citasBLL;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<ResponseListAppointments>> ObtainAppointments()
        {
            try
            {
                var resultado = await _appointmentsBLL.ListAppointments();
                return resultado;
            }

            catch (Exception)

            {

                ResponseListAppointments responseAppointments = new ResponseListAppointments();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al obtener la lista de citas";
                responseAppointments.Errors = responseModel;
                return responseAppointments;



            }
        }   

        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult<ResponseAppointments>> Crear(Appointments appointment)
        {
            try
            {
                var response = await _appointmentsBLL.Crear(appointment);
                return new JsonResult(response);
            }
            catch (Exception)
            {
                var responseCitas = new ResponseAppointments();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al insertar las citas";
                responseCitas.Errors = responseModel;
                return new JsonResult(responseCitas);
            }
        }

    }
}
