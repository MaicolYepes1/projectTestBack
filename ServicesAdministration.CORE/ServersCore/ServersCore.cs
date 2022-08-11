using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesAdministration.CORE.ServersCore.Interfaces;
using ServicesAdministration.DATA.Context;
using ServicesAdministration.MODELS.Entities;
using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.CORE.ServersCore
{
    public class ServersCore : IServersCore
    {
        #region Dependency
        private readonly ServicesTestContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ServersCore(ServicesTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        public async Task<List<ServerModel>> GetAll()
        {
            var res = _context.Servers.ToList();
            if (res.Count != 0)
            {
                var map = _mapper.Map<List<ServerModel>>(res);
                map.ForEach(x =>
                {
                    x.ClientId = _context.HomologationClientServices.Where(x => x.ServerId == x.ServerId).Select(y => y.ClientId).FirstOrDefault();
                });
                return await Task.FromResult(map);
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> CreateOrUpdate(ServerRequest model)
        {
            var map = _mapper.Map<Server>(model);

            if (map.ServerId != 0)
            {
                var exist = _context.Servers.Where(_x => _x.ServerId == map.ServerId).AsNoTracking().ToList();
                if (exist.Find(x => x.ServerId != map.ServerId) != null)
                {
                    return false;
                }
                _context.Servers.Update(map);
                var res = _context.SaveChangesAsync();
                if (model.Servicios.Count != 0)
                {
                    for (int i = 0; i < model.Servicios.Count; i++)
                    {
                        HomologationClientServiceModel homologacion = new HomologationClientServiceModel();
                        homologacion.ServerId = map.ServerId;
                        homologacion.ServiceId = model.Servicios[i];
                        homologacion.ClientId = model.ClientId;
                        var homoMap = _mapper.Map<HomologationClientService>(homologacion);
                        _context.HomologationClientServices.Add(homoMap);
                        await _context.SaveChangesAsync();
                    }
                }
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
            else
            {
                var exist = _context.Servers.Where(_x => _x.ServerId == map.ServerId).FirstOrDefault();
                if (exist != null)
                {
                    return false;
                }
                _context.Servers.Add(map);
                var res = await _context.SaveChangesAsync();
                if (model.Servicios.Count != 0)
                {
                    for (int i = 0; i < model.Servicios.Count; i++)
                    {
                        try
                        {
                            HomologationClientServiceModel homologacion = new HomologationClientServiceModel();
                            homologacion.ServerId = map.ServerId;
                            homologacion.ServiceId = model.Servicios[i];
                            homologacion.ClientId = model.ClientId;
                            var homoMap = _mapper.Map<HomologationClientService>(homologacion);
                            _context.HomologationClientServices.Add(homoMap);
                            var saveHomo = await _context.SaveChangesAsync();
                        }
                        catch (Exception e)
                        {

                            throw;
                        }
                    }
                }
                return await Task.FromResult(Convert.ToBoolean(res));
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                var serverDeleted = _context.Servers.Where(x => x.ServerId == id).FirstOrDefault();
                _context.Servers.Remove(serverDeleted);
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
