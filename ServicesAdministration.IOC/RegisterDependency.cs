using Microsoft.Extensions.DependencyInjection;
using ServicesAdministration.CORE.ClientsCore;
using ServicesAdministration.CORE.ClientsCore.Interfaces;
using ServicesAdministration.CORE.Helpers;
using ServicesAdministration.CORE.Helpers.Interfaces;
using ServicesAdministration.CORE.LoginCore;
using ServicesAdministration.CORE.LoginCore.Interfaces;
using ServicesAdministration.CORE.ServersCore;
using ServicesAdministration.CORE.ServersCore.Interfaces;
using ServicesAdministration.CORE.ServicesCore;
using ServicesAdministration.CORE.ServicesCore.Interfaces;
using ServicesAdministration.CORE.UserCore;
using ServicesAdministration.CORE.UserCore.Interfaces;

namespace ServicesAdministration.IOC
{
    public class RegisterDependency
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped<ILoginCore, LoginCore>();
            services.AddScoped<IUserCore, UserCore>();
            services.AddScoped<IGenerateJtwToken, GenerateJtwToken>();
            services.AddScoped<IEncriptAndDesencriptPassword, EncriptAndDesencriptPassword>();
            services.AddScoped<IClientsCore, ClientsCore>();
            services.AddScoped<IServersCore, ServersCore>();
            services.AddScoped<IServicesCore, ServicesCore>();
            #endregion

        }
    }
}
