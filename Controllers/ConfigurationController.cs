using CargoCompany.Models;
using CargoCompany.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CargoCompany.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigRepository<CarrierConfigurations> _configurationRepository;

        public ConfigurationController(IConfigRepository<CarrierConfigurations> configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        [HttpGet]
        public IActionResult GetAllConfigurations()
        {
            var configurations = _configurationRepository.GetAll();
            return Ok(configurations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _configurationRepository.GetById(id);
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> AddConfiguration(CarrierConfigurations configuration)
        {
            var result = await _configurationRepository.AddAsync(configuration);
            if (!result)
            {
                return NotFound();
            }
            return CreatedAtAction("GetById", new { id = configuration.CarrierConfigurationId }, configuration);
        }

        [HttpPut]
        public IActionResult UpdateConfiguration([FromBody] CarrierConfigurations updatedConfiguration)
        {
            var result = _configurationRepository.Update(updatedConfiguration);

            if (result)
            {
                return Ok(new { Message = "Configuration updated successfully." });
            }
            else
            {
                return BadRequest(new { Message = "Failed to update configuration." });
            }
        }

        [HttpDelete]
        public IActionResult DeleteConfiguration([FromBody] CarrierConfigurations configurationToDelete)
        {
            var result = _configurationRepository.Delete(configurationToDelete);

            if (result)
            {
                return Ok(new { Message = "Configuration deleted successfully." });
            }
            else
            {
                return BadRequest(new { Message = "Failed to delete configuration." });
            }
        }
    }
}
