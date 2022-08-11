using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.CORE.ServicesCore.Interfaces
{
    public interface IServicesCore
    {
        Task<List<ServiceModel>> GetAll();
        Task<bool> CreateOrUpdate(ServiceRequest model);
        Task<bool> Delete(int id);
    }
}
