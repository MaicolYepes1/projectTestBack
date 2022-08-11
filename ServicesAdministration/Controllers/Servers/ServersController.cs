using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesAdministration.CORE.ServersCore.Interfaces;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.Controllers.Servers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        #region Dependency
        private readonly IServersCore _servers;
        #endregion

        #region Constructor
        public ServersController(IServersCore servers)
        {
            _servers = servers;
        }
        #endregion


        #region Methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _servers.GetAll();
                return res != null ? Ok(res) : NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(ServerRequest model)
        {
            try
            {
                var res = await _servers.CreateOrUpdate(model);
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
                var res = await _servers.Delete(id);
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
