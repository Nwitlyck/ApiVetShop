using ApiVetShop.BLL;
using ApiVetShop.IBLL;
using ApiVetShop.Models;
using ApiVetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiVetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsBLL _detailsBLL;

        public DetailsController(IDetailsBLL detailsBLL)
        {
            _detailsBLL = detailsBLL;
        }

        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<ResponseListDetails>> ObtainDetails()
        {
            try
            {
                var resultado = await _detailsBLL.ListDetails();
                return resultado;
            }
            catch (Exception)
            {

                var responseDetails = new ResponseListDetails();

                var responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al obtener la lista de Detalles";
                responseDetails.Errors = responseModel;

                return responseDetails;

            }
        }
    }
}
