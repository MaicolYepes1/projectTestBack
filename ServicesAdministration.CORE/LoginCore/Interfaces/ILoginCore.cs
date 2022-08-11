using ServicesAdministration.MODELS.Request;
using ServicesAdministration.MODELS.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAdministration.CORE.LoginCore.Interfaces
{
    public interface ILoginCore
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }
}
