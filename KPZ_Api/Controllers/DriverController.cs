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
        public IActionResult GetDrivers()
        {
            var drivers = _mapper.Map<List<DriverDto>>(_driverInterface.GetDrivers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(drivers);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Driver))]
        [ProducesResponseType(400)]
        public IActionResult GetDriver(int id)
        {
            if (!_driverInterface.DriverExists(id))
                return NotFound();

            var driver = _mapper.Map<DriverDto>(_driverInterface.GetDriver(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(driver);
        }
    }
}
