namespace IIOT.Dottor.FrostManager.Web.Controllers
{
    using IIOT.Dottor.FrostManager.Application;
    using IIOT.Dottor.FrostManager.Application.Models;
    using IIOT.Dottor.FrostManager.Web.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/frost")]
    [ApiController]
    public class FrostController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public FrostController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // POST api/frost
        [HttpPost]
        public async Task<IActionResult> SaveTemperature(DeviceTemperatureModel model)
        {
            try
            {
                TemperatureMessage message = new()
                {
                    DeviceId = model.DeviceId,
                    MeasurementDate = model.MeasurementDate,
                    TemperatureDesired = model.TemperatureDesired,
                    TemperatureMeasured = model.TemperatureMeasured
                };
                await _messageService.SendDataAsync(message);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500,new { Message = ex.Message });
            }
        }

        // GET api/frost/{id}
        [HttpGet("{id}")]
        public IActionResult GetAllTemperatures(int id)
        {
            throw new NotImplementedException();
        }




    }
}
