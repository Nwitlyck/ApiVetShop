using ApiVetShop.Models;
using System.Data.SqlTypes;

namespace ApiVetShop.IRepository
{
    public interface IAppointmetsRepository
    {
        public Task<IEnumerable<Appoiments>> ListAppointmets();
        public Task<Appoiments> GetAppointmest(int id);
        public Task<Appoiments> UpdateAppointment(int id, 
                                                  string NewUserName, 
                                                  string NewCustomerName, 
                                                  string NewUnitName, 
                                                  string NewSiteName,
                                                  string NewAsistantName,
                                                  DateTime NewDateTime,
                                                  string NewAdress,
                                                  string NewCanton,
                                                  string NewProvince,
                                                  string NewDescription,
                                                  string NewState);
    }
}
