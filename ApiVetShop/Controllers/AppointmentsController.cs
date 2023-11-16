﻿using ApiVetShop.BLL;
using ApiVetShop.IBLL;
using ApiVetShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiVetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppoinmentsBLL _appoinmentBLL;
        public AppointmentsController(IAppoinmentsBLL citasBLL)
        {
            _appoinmentBLL = citasBLL;
        }

        [HttpGet]
        [Route("List")]
        public async Task<ActionResult<ResponseListAppointments>> ObtainAppointmentsList(int userId)
        {
            try
            {
                var resultado = await _appoinmentBLL.ListAppointments(userId);
                return resultado;
            }

            catch (Exception)

            {

                var responseAppointments = new ResponseListAppointments();

                var responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al obtener la lista de citas";
                responseAppointments.Errors = responseModel;
                return responseAppointments;



            }
        }   

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult<ResponseAppointments>> Update(Appoiments appointment)
        {
            try
            {
                var response = await _appoinmentBLL.UpdateAppointment(appointment);
                return new JsonResult(response);
            }
            catch (Exception)
            {
                var responseCitas = new ResponseAppointments();

                var responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al insertar las citas";
                responseCitas.Errors = responseModel;
                return new JsonResult(responseCitas);
            }
        }

    }
}
