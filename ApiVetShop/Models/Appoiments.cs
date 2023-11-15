namespace ApiVetShop.Models
{
    public class Appoiments
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string CustomerName { get; set; }
        public string unitName { get; set; }
        public string? siteName { get; set; }
        public string? asistantName { get; set; }

        public string adress { get; set; }
        public string canton { get; set; }
        public string province { get; set; }
        public string? description { get; set; }
        public string state { get; set; }
    }
}
