using ApiVetShop.BLL;
using ApiVetShop.IBLL;
using ApiVetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiVetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersBLL _userBLL;

        public UserController(IUsersBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpGet]
        [Route("Select")]
        public async Task<ActionResult<ResponseUsers>> ObtainUsers(int id)
        {
            try
            {
                return await _userBLL.SelectUser(id);

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
        public async Task<ActionResult<ResponseVerify>> ObtainUsers(string email, string password)
        {
            try
            {
                return await _userBLL.VerifyUser(email, password);

            }
            catch (Exception)
            {

                var responseVerify = new ResponseVerify();

                var responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al buscar el Usuario";
                responseVerify.Errors = responseModel;
                return new JsonResult(responseVerify);
            }
        }

    }
}
