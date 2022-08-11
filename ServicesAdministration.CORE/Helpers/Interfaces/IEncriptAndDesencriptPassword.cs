using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAdministration.CORE.Helpers.Interfaces
{
    public interface IEncriptAndDesencriptPassword
    {
        Task<string> Desencript(string password);
        Task<string> Encryptpass(string password);
    }
}
