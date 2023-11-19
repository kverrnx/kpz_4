using AutoMapper;
using KPZ_Api.Dto;
using KPZ_Api.Interfaces;
using KPZ_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace KPZ_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : Controller
    {
        private readonly ITripInterface _tripInterface;
        private readonly IMapper _mapper;
        public TripController(ITripInterface tripInterface, IMapper mapper)
        {
            _tripInterface = tripInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Trip>))]
        public IActionResult GetTrips()
        {
            var trips = _mapper.Map<List<TripDto>>(_tripInterface.GetTrips());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(trips);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Trip))]
        [ProducesResponseType(400)]
        public IActionResult GetTrip(int id)
        {
            if (!_tripInterface.TripExists(id))
                return NotFound();

            var trip = _mapper.Map<TripDto>(_tripInterface.GetTrip(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(trip);
        }
    }
}
