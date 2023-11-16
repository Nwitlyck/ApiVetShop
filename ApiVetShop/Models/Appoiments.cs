namespace ApiVetShop.Models
{
    public class Appoiments
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? CustomerName { get; set; }
        public string? UnitName { get; set; }
        public string? SiteName { get; set; }
        public string? AsistantName { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Address { get; set; }
        public string? Canton { get; set; }
        public string? Province { get; set; }
        public string? Description { get; set; }
        public int State { get; set; }
    }
}
