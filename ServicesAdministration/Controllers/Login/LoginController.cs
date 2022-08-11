using Microsoft.AspNetCore.Mvc;
using ServicesAdministration.CORE.LoginCore.Interfaces;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Dependency
        private readonly ILoginCore _login;
        #endregion

        #region Constructor
        public LoginController(ILoginCore login)
        {
            _login = login;
        }
        #endregion

        #region Methods
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _login.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new { message = "Username o password Incorrectos" });
            }

            return StatusCode(200, response);
        }
        #endregion
    }
}
