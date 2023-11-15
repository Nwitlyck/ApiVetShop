namespace ApiVetShop.Models
{
    public class ResponseUsers
    {
        public Users User { get; set; } = new Users();
        public ResponseModel Errors { get; set; } = new ResponseModel();
    }
}
