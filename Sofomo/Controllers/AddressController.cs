using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sofomo.Common;
using Sofomo.DTO;
using Sofomo.Extension;
using Sofomo.IpStack;
using Sofomo.Logic;

namespace Sofomo.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private ILogger<AddressController> _logger;
        private ILogic _logic { get; set; }
        private IIpStackClient _ipStackClient;

        public AddressController(ILogger<AddressController> logger, ILogic logic, IIpStackClient ipStackClient)
        {
            _logic = logic;
            _logger = logger;
            _ipStackClient = ipStackClient;
        }
        [HttpGet]
        public IActionResult Get(string address)
        {
            try
            {
             
                if (!Validators.IsValidURL(address))
                    return StatusCode((int)HttpStatusCode.NotAcceptable);
                if (Validators.IsIp(address))
                {
                    IPAddress IpAddress;
                    if (!IPAddress.TryParse(address, out IpAddress))
                        return StatusCode((int)HttpStatusCode.NotAcceptable);
                }
                address = Helpers.PrepareUrl(address);
                IpInfoDTO model = new IpInfoDTO();
                model = _logic.Get(address);

                if (model == null)
                {
                    _logger.LogWarning($"Entity with address: {address} not found in database.");
                    model = _ipStackClient.GetAddressInfo(address);
                }
                if (model == null)
                {
                    _logger.LogWarning($"Entity with address: {address} not found in IpStack Api.");
                    return StatusCode(404);
                }
                return Ok(model);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                return StatusCode(500);
            }
        }
        [HttpPost]
        public IActionResult Post(string address)
        {
            try
            {
                if (!Validators.IsValidURL(address))
                    return StatusCode((int)HttpStatusCode.NotAcceptable);
                if (Validators.IsIp(address))
                {
                    IPAddress IpAddress;
                    if (!IPAddress.TryParse(address, out IpAddress))
                        return StatusCode((int)HttpStatusCode.NotAcceptable);
                }
                address = Helpers.PrepareUrl(address);
                _logger.LogInformation($"Adding Entity with address {address}");
                IpInfoDTO model = new IpInfoDTO();
                model = _logic.Get(address);
                if (model == null)
                {
                    _logger.LogWarning($"Entity with address: {address} doesn't exists in DB.");
                    _logger.LogInformation($"Fetching IpInfo from IpStack API");
                    model = _ipStackClient.GetAddressInfo(address);
                }
                else
                {
                    return Ok(_logic.Add(model));
                }
                if (model != null)
                {
                    _logger.LogInformation($"Saving Entity with address {address} to DB");
                    return Ok(_logic.Add(model));
                }
                _logger.LogWarning($"Entity with address: {address} doesn't exists in IpStack Api and DB.");
                return StatusCode((int)HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                return StatusCode(500);
            }

        }
        [HttpDelete]
        public IActionResult Delete(string address)
        {
            try
            {
                if (!Validators.IsValidURL(address))
                    return StatusCode((int)HttpStatusCode.NotAcceptable);
                if (Validators.IsIp(address))
                {
                    IPAddress IpAddress;
                    if (!IPAddress.TryParse(address, out IpAddress))
                        return StatusCode((int)HttpStatusCode.NotAcceptable);
                }
                address = Helpers.PrepareUrl(address);
                _logger.LogInformation($"Deleting Entity with address {address}");
                return StatusCode((int)_logic.Delete(address));
            }
            catch (Exception e)
            {
                _logger.LogCritical(e.Message);
                return StatusCode(500);
            }

        }
    }
}