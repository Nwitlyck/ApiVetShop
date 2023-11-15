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
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _userBLL;

        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpGet]
        [Route("Seleccionar")]
        public async Task<ActionResult<ResponseUsers>> ObtenerUsers(int id)
        {
            try
            {
                return await _userBLL.ObtenerUsers(id);

            }
            catch (Exception)
            {

                ResponseUsers responseUsers = new ResponseUsers();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al buscar el Usuario";
                responseUsers.Errors = responseModel;
                return new JsonResult(responseUsers);
            }
        }

        [HttpGet]
        [Route("Verify")]
        public async Task<ActionResult<ResponseUsers>> ObtenerUsers(string email, string password)
        {
            try
            {
                return await _userBLL.ObtenerUsers(email, password);

            }
            catch (Exception)
            {

                ResponseUsers responseUsers = new ResponseUsers();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al buscar el Usuario";
                responseUsers.Errors = responseModel;
                return new JsonResult(responseUsers);
            }
        }

    }
}
