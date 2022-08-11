using AutoMapper;
using ServicesAdministration.CORE.Helpers.Interfaces;
using ServicesAdministration.CORE.LoginCore.Interfaces;
using ServicesAdministration.DATA.Context;
using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;
using ServicesAdministration.MODELS.Response;

namespace ServicesAdministration.CORE.LoginCore
{
    public class LoginCore : ILoginCore
    {

        #region Dependency
        private readonly ServicesTestContext _context;
        private readonly IEncriptAndDesencriptPassword _password;
        private readonly IGenerateJtwToken _jtwGenerate;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public LoginCore(ServicesTestContext context, IEncriptAndDesencriptPassword password, IGenerateJtwToken jtwToken, IMapper mapper)
        {
            _context = context;
            _password = password;
            _jtwGenerate = jtwToken;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            var map = _mapper.Map<UserModel>(user);
            var decodePassword = await _password.Desencript(user.Password);
            var passwordRequestDecode = await _password.Desencript(map.Password);
            if (decodePassword == passwordRequestDecode)
            {
                var token = await _jtwGenerate.GenerateJwtToken(map);
                return  await Task.FromResult(new AuthenticateResponse(map, token));
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
