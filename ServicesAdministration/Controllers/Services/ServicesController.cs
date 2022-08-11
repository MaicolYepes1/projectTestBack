using Microsoft.AspNetCore.Mvc;
using ServicesAdministration.CORE.ServicesCore.Interfaces;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.Controllers.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        #region Dependency
        private readonly IServicesCore _services;
        #endregion

        #region Constructor
        public ServicesController(IServicesCore service)
        {
            _services = service;
        }
        #endregion


        #region Methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _services.GetAll();
                return res != null ? Ok(res) : NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(ServiceRequest model)
        {
            try
            {
                var res = await _services.CreateOrUpdate(model);
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
                var res = await _services.Delete(id);
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
