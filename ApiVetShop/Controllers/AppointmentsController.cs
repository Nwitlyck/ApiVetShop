using APICurso.BLL;
using APICurso.IBLL;
using APICurso.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiVetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ICitasBLL _citasBLL;
        public CitasController(ICitasBLL citasBLL)
        {
            _citasBLL = citasBLL;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<ActionResult<ResponseListaClientes> ObtenerCitas()
        {
            try
            {
                var resultado = await _citasBLL.ListaCitas();
                return resultado;
            }
            catch (Exception)
            {

                ResponseListaClientes responseCitas = new ResponseListaClientes();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al obtener la lista de citas";
                responseCitas.errores = responseModel;
                return responseCitas;



            }
        }   

        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult<ResponseCliente>> Crear(Citas citas)
        {
            try
            {
                var response = await _citasBLL.Crear(citas);
                return new JsonResult(response);
            }
            catch (Exception)
            {
                ResponseCliente responseCitas = new ResponseCliente();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al insertar las citas";
                responseCitas.errores = responseModel;
                return new JsonResult(responseCitas);
            }
        }



    }
}
