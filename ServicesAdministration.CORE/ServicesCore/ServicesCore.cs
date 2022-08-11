using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesAdministration.CORE.ServicesCore.Interfaces;
using ServicesAdministration.DATA.Context;
using ServicesAdministration.MODELS.Entities;
using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.CORE.ServicesCore
{
    public class ServicesCore : IServicesCore
    {
        #region Dependency
        private readonly ServicesTestContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ServicesCore(ServicesTestContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        public async Task<List<ServiceModel>> GetAll()
        {
            var res = _context.Services.ToList();
            if (res.Count != 0)
            {
                var map = _mapper.Map<List<ServiceModel>>(res);
                return await Task.FromResult(map);
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> CreateOrUpdate(ServiceRequest model)
        {
            var map = _mapper.Map<Service>(model);

            if (map.ServiceId != 0)
            {
                var exist = _context.Services.Where(_x => _x.ServiceId == map.ServiceId).AsNoTracking().ToList();
                if (exist.Find(x => x.ServiceId != map.ServiceId) != null)
                {
                    return false;
                }
                _context.Services.Update(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
            else
            {
                var exist = _context.Services.Where(_x => _x.ServiceId == map.ServiceId).FirstOrDefault();
                if (exist != null)
                {
                    return false;
                }
                _context.Services.Add(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                var serviceDeleted = _context.Services.Where(x => x.ServiceId == id).FirstOrDefault();
                _context.Services.Remove(serviceDeleted);
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
