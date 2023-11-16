using ApiVetShop.IBLL;
using ApiVetShop.IRepository;
using ApiVetShop.Models;
using ApiVetShop.Repository;

namespace ApiVetShop.BLL
{
    public class DetailsBLL : IDetailsBLL
    {
        private IDetailsRepository _detailsRepository;
        public DetailsBLL(IDetailsRepository detailsRepository) 
        {
            _detailsRepository = detailsRepository;
        }
        public async Task<ResponseListDetails> ListDetails()
        {
            try
            {
                var listDetails = await _detailsRepository.ListDetails();

                var responseListDetails = new ResponseListDetails();
                responseListDetails.Details = listDetails.ToList();

                var responseModel = new ResponseModel();
                responseModel.errorcode = 0;
                responseModel.errormsg = "Lista de detalles devuelta con éxito";

                responseListDetails.Errors = responseModel;

                return responseListDetails;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
