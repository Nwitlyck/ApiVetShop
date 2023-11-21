using ApiVetShop.Helpers;
using ApiVetShop.IBLL;
using ApiVetShop.IRepository;
using ApiVetShop.Models;

namespace ApiVetShop.BLL
{
    public class UsersBLL : IUsersBLL
    {
        private IUsersRepository _usersRepository;
        private readonly EncrypAPICall _encrypAPICall;
        public UsersBLL(IUsersRepository usersRepository, EncrypAPICall encrypAPICall)
        {
            _usersRepository = usersRepository;
            _encrypAPICall = encrypAPICall;
        }
        public async Task<ResponseUsers> SelectUser(string email)
        {
            try
            {
                var user = await _usersRepository.SelectUser(email);

                var responseUsers = new ResponseUsers();
                var responseModel = new ResponseModel();


                if (user != null)
                {
                    responseUsers.User = user;
                    responseModel.errorcode = 0;
                    responseModel.errormsg = "Usuario encontrado con éxito";

                }
                else
                {
                    responseModel.errorcode = 1;
                    responseModel.errormsg = "No se ha podido encontrar el usuario con el correo: " + email;
                }

                responseUsers.Errors = responseModel;
                return responseUsers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseVerify> VerifyUser(string email, string password)
        {
            try
            {

                var encrypted = await _encrypAPICall.GetEncrypt(password);

                var flag = await _usersRepository.VerifyUser(email, encrypted.encryp);

                var responseVerify = new ResponseVerify();
                var responseModel = new ResponseModel();

                responseVerify.Flag = flag;

                if (flag)
                {
                    responseModel.errorcode = 0;
                    responseModel.errormsg = "Las credenciales se han encontrado con éxito";

                }
                else
                {
                    responseModel.errorcode = 1;
                    responseModel.errormsg = "Las credenciales no se han encontrado con éxito";
                }

                responseVerify.Errors = responseModel;
                return responseVerify;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
