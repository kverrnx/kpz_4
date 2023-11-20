using AutoMapper;
using KPZ_Api.Dto;
using KPZ_Api.Interfaces;
using KPZ_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace KPZ_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : Controller
    {
        private readonly IDriverInterface _driverInterface;
        private readonly IMapper _mapper;
        public DriverController(IDriverInterface driverInterface, IMapper mapper)
        {
            _driverInterface = driverInterface;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Driver>))]
        public async Task<IActionResult> GetDrivers()
        {
            var drivers = _mapper.Map<List<DriverDto>>(await _driverInterface.GetDrivers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(drivers);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Driver))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetDriver(int id)
        {
            if (!await _driverInterface.DriverExists(id))
                return NotFound();

            var driver = _mapper.Map<DriverDto>(await _driverInterface.GetDriver(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(driver);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateDriver([FromBody] Driver driverCreate)
        {
            if (driverCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var driverMap = _mapper.Map<Driver>(driverCreate);

            if (!await _driverInterface.CreateDriver(driverMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateDriver(int id, [FromBody] Driver updatedDriver)
        {
            if (updatedDriver is null)
                return BadRequest(ModelState);

            if (id != updatedDriver.Id)
                return BadRequest(ModelState);

            if (!await _driverInterface.DriverExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var driverMap = _mapper.Map<Driver>(updatedDriver);

            if (!await _driverInterface.UpdateDriver(driverMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            if (!await _driverInterface.DriverExists(id))
                return NotFound();

            var driverToDelete = await _driverInterface.GetDriver(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _driverInterface.DeleteDriver(driverToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
