using ApiVetShop.IBLL;
using ApiVetShop.IRepository;
using ApiVetShop.Models;

namespace ApiVetShop.BLL
{
    public class UsersBLL : IUsersBLL
    {
        private IUsersRepository _usersRepository;
        public UsersBLL(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<ResponseUsers> SelectUser(int id)
        {
            try
            {
                var user = await _usersRepository.SelectUser(id);

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
                    responseModel.errormsg = "No se ha podido encontrar el usuario con el id: " + id.ToString();
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
                var flag = await _usersRepository.VerifyUser(email, password);

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
