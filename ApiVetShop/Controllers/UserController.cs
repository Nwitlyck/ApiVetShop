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
        public async Task<ActionResult<ResponseUsers>> ObtainUsers(string email)
        {
            try
            {
                return await _userBLL.SelectUser(email);

            }
            catch (Exception)
            {

                var responseUsers = new ResponseUsers();

                var responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al buscar el Usuario";
                responseUsers.Errors = responseModel;
                return new JsonResult(responseUsers);
            }
        }

        [HttpPost]
        [Route("Verify")]
        public async Task<ActionResult<ResponseVerify>> ObtainUsers(LogIn logIn)
        {
            try
            {
                return await _userBLL.VerifyUser(logIn);

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
