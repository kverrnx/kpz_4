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
        public async Task<IActionResult> GetTrips()
        {
            var trips = _mapper.Map<List<TripDto>>(await _tripInterface.GetTrips());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(trips);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Trip))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTrip(int id)
        {
            if (!await _tripInterface.TripExists(id))
                return NotFound();

            var trip = _mapper.Map<TripDto>(await _tripInterface.GetTrip(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(trip);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTrip([FromBody] Trip tripCreate)
        {
            if (tripCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tripMap = _mapper.Map<Trip>(tripCreate);

            if (!await _tripInterface.CreateTrip(tripMap))
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
        public async Task<IActionResult> UpdateTrip(int id, [FromBody] Trip updatedTrip)
        {
            if (updatedTrip is null)
                return BadRequest(ModelState);

            if (id != updatedTrip.Id)
                return BadRequest(ModelState);

            if (!await _tripInterface.TripExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var tripMap = _mapper.Map<Trip>(updatedTrip);

            if (!await _tripInterface.UpdateTrip(tripMap))
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
        public async Task<IActionResult> DeleteTrip(int id)
        {
            if (!await _tripInterface.TripExists(id))
                return NotFound();

            var tripToDelete = await _tripInterface.GetTrip(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _tripInterface.DeleteTrip(tripToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
