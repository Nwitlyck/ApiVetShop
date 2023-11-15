namespace APICurso.Models
{
    public class ResponseCliente
    {
        public Client cliente { get; set; } = new Client();
        public ResponseModel errores { get; set; } = new ResponseModel();  
    }
}
