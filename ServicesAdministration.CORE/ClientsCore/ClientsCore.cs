using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesAdministration.CORE.ClientsCore.Interfaces;
using ServicesAdministration.DATA.Context;
using ServicesAdministration.MODELS.Entities;
using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.CORE.ClientsCore
{
    public class ClientsCore : IClientsCore
    {
        #region Dependency
        private readonly ServicesTestContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ClientsCore(ServicesTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        public async Task<List<ClientModel>> GetAll()
        {
            var res = _context.Clients.ToList();
            if (res.Count != 0)
            {
                var map = _mapper.Map<List<ClientModel>>(res);
                return await Task.FromResult(map);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CreateOrUpdate(ClientRequest model)
        {
            var map = _mapper.Map<Client>(model);

            if (map.ClientId != 0)
            {
                var exist = _context.Clients.Where(_x => _x.ClientId == map.ClientId).AsNoTracking().ToList();
                if (exist.Find(x => x.ClientId != map.ClientId) != null)
                {
                    return false;
                }
                _context.Clients.Update(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
            else
            {
                var exist = _context.Clients.Where(_x => _x.ClientId == map.ClientId).FirstOrDefault();
                if (exist != null)
                {
                    return false;
                }
                _context.Clients.Add(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                var clientDeleted = _context.Clients.Where(x => x.ClientId == id).FirstOrDefault();
                _context.Clients.Remove(clientDeleted);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
            else
            {
                return await Task.FromResult(Convert.ToBoolean(false));
            }
        }
        #endregion
    }
}
