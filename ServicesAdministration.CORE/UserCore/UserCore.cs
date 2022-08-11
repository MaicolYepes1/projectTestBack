using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesAdministration.CORE.Helpers.Interfaces;
using ServicesAdministration.CORE.UserCore.Interfaces;
using ServicesAdministration.DATA.Context;
using ServicesAdministration.MODELS.Entities;
using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.CORE.UserCore
{
    public class UserCore : IUserCore
    {
        #region Dependency
        private readonly ServicesTestContext _context;
        private readonly IMapper _mapper;
        private readonly IEncriptAndDesencriptPassword _password;
        #endregion

        #region Constructor
        public UserCore(ServicesTestContext context, IMapper mapper, IEncriptAndDesencriptPassword password)
        {
            _context = context;
            _mapper = mapper;
            _password = password;
        }
        #endregion

        #region Methods

        public async Task<List<UserModel>> GetAll()
        {
            var res = _context.Users.ToList();
            if (res.Count != 0)
            {
                var map = _mapper.Map<List<UserModel>>(res);
                return await Task.FromResult(map);
            }
            else
            {
                return null;
            }
        }


        public async Task<List<UserModel>> GetByClientId(int Id)
        {
            var res = _context.Users.Where(z => z.ClientId == Id).ToList();
            if (res.Count != 0)
            {
                var map = _mapper.Map<List<UserModel>>(res);
                return await Task.FromResult(map);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CreateOrUpdate(UserRequest model)
        {
            var map = _mapper.Map<User>(model);

            if (map.UserId != 0)
            {
                var exist = _context.Users.Where(_x => _x.Email == map.Email).AsNoTracking().ToList();
                if (exist.Find(x => x.UserId != map.UserId) != null)
                {
                    return false;
                }
                map.Password = await _password.Encryptpass(map.Password);
                _context.Users.Update(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
            else
            {
                var exist = _context.Users.Where(_x => _x.UserId == map.UserId).FirstOrDefault();
                if (exist != null)
                {
                    return false;
                }
                map.Password = await _password.Encryptpass(map.Password);
                _context.Users.Add(map);
                var res = _context.SaveChangesAsync();
                return await Task.FromResult(Convert.ToBoolean(res.Result));
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (id != 0)
            {
                var userDeleted = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
                _context.Users.Remove(userDeleted);
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
