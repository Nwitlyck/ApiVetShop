namespace ApiVetShop.Models
{
    public class ResponseListDetails
    {
        public List<Details> Details { get; set; } = new List<Details>();
        public ResponseModel Errors { get; set; } = new ResponseModel();
    }
}
