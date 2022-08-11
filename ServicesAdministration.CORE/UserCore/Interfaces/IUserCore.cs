using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.CORE.UserCore.Interfaces
{
    public interface IUserCore
    {
        Task<List<UserModel>> GetAll();
        Task<List<UserModel>> GetByClientId(int Id);
        Task<bool> CreateOrUpdate(UserRequest model);
        Task<bool> Delete(int id);
    }
}
