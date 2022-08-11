using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.CORE.ServersCore.Interfaces
{
    public interface IServersCore
    {

        Task<List<ServerModel>> GetAll();
        Task<bool> CreateOrUpdate(ServerRequest model);
        Task<bool> Delete(int id);
    }
}
