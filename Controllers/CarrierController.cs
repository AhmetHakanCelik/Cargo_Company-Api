using CargoCompany.Models;
using CargoCompany.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CargoCompany.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly IRepository<Carriers> _carrierRepository;

        public CarrierController(IRepository<Carriers> carrierRepository)
        {
            _carrierRepository = carrierRepository;
        }

        [HttpGet]
        public IActionResult GetAllCarriers()
        {
            var carriers = _carrierRepository.GetAll();
            return Ok(carriers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _carrierRepository.GetById(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarrier(Carriers carrier)
        {
            var result = await _carrierRepository.AddAsync(carrier);
            if (!result)
            {
                return NotFound();
            }
            return CreatedAtAction("GetById", new { id = carrier.CarrierId }, carrier);
        }

        [HttpPut("{CarrierName}")]
        public IActionResult UpdateCarrier([FromBody] Carriers updatedCarrier)
        {
            var result = _carrierRepository.Update(updatedCarrier);

            if (result)
            {
                return Ok(new { Message = "Carrier updated successfully." });
            }
            else
            {
                return BadRequest(new { Message = "Failed to update carrier." });
            }
        }

        [HttpDelete]
        public IActionResult DeleteCarrier([FromBody] Carriers carrierToDelete)
        {
            var result = _carrierRepository.Delete(carrierToDelete);

            if (result)
            {
                return Ok(new { Message = "Carrier deleted successfully." });
            }
            else
            {
                return BadRequest(new { Message = "Failed to delete carrier." });
            }
        }
    }
}