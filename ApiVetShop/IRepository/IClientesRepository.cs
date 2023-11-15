using APICurso.Models;

namespace APICurso.IRepository
{
    public interface IClientesRepository
    {
        public Task<int> Crear(Client cliente);
        public Task<IEnumerable<Client>> ListaClientes();

        public Task<Client> ObtenerCliente(int id);

    }
}
