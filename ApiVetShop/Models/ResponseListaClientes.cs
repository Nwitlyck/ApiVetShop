namespace APICurso.Models
{
    public class ResponseListaClientes
    {
        public  List<Client> clientes { get; set; } = new List<Client>();
        public ResponseModel errores { get; set; } = new ResponseModel();

    }
}
