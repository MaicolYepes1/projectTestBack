using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.CORE.ClientsCore.Interfaces
{
    public interface IClientsCore
    {
        Task<List<ClientModel>> GetAll();
        Task<bool> CreateOrUpdate(ClientRequest model);
        Task<bool> Delete(int id);
    }
}
