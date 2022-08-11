using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesAdministration.CORE.UserCore.Interfaces;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Dependency
        private readonly IUserCore _user;
        #endregion

        #region Constructor
        public UserController(IUserCore user)
        {
            _user = user;
        }
        #endregion


        #region Methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _user.GetAll();
                return res != null ? Ok(res) : NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }


        [HttpGet]
        [Route("GetByClientId/{Id}")]
        public async Task<IActionResult> GetByClientId(int Id)
        {
            try
            {
                var res = await _user.GetByClientId(Id);
                return res != null ? Ok(res) : NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(UserRequest model)
        {
            try
            {
                var res = await _user.CreateOrUpdate(model);
                return res != false ? Ok(res) : BadRequest();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var res = await _user.Delete(id);
                return res == false ? BadRequest() : Ok(res);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
        #endregion
    }
}
