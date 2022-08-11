﻿using Microsoft.AspNetCore.Mvc;
using ServicesAdministration.CORE.ClientsCore.Interfaces;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.Controllers.Clients
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        #region Dependency
        private readonly IClientsCore _clients;
        #endregion

        #region Constructor
        public ClientsController(IClientsCore clients)
        {
            _clients = clients;
        }
        #endregion


        #region Methods

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _clients.GetAll();
                return res != null ? Ok(res) : NotFound();
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(ClientRequest model)
        {
            try
            {
                var res = await _clients.CreateOrUpdate(model);
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
                var res = await _clients.Delete(id);
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
