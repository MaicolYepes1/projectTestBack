using ServicesAdministration.MODELS.Models;

namespace ServicesAdministration.CORE.Helpers.Interfaces
{
    public interface IGenerateJtwToken
    {
        Task<string> GenerateJwtToken(UserModel user);
    }
}
