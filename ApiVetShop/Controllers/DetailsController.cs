﻿using APICurso.BLL;
using APICurso.IBLL;
using APICurso.Models;
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
        [Route("Listar")]
        public async Task<ActionResult<ResponseDetails>> ObtainDetails()
        {
            try
            {
                var resultado = await _detailsBLL.ListaDetails();
                return resultado;
            }
            catch (Exception)
            {

                var responseDetails = await new ResponseListDetails();

                ResponseModel responseModel = new ResponseModel();
                responseModel.errorcode = -1;
                responseModel.errormsg = "Error al obtener la lista de Detalles";
                responseDetails.Errors = responseModel;
                return responseDetails;



            }
        }
    }
}