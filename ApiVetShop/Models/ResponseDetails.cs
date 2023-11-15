namespace ApiVetShop.Models
{
    public class ResponseDetails
    {
        public Details Detail { get; set; } = new Details();
        public ResponseModel Errors { get; set; } = new ResponseModel();
    }
}
