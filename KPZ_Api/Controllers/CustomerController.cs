using AutoMapper;
using KPZ_Api.Dto;
using KPZ_Api.Interfaces;
using KPZ_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace KPZ_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerInterface _customerInterface;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerInterface customerInterface, IMapper mapper)
        {
            _customerInterface = customerInterface;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Customer>))]
        public async Task<IActionResult> GetCustomers() 
        {
            var customers = _mapper.Map<List<CustomerDto>>(await _customerInterface.GetCustomers());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCustomer(int id)
        {
            if(!await _customerInterface.CustomerExists(id))
                return NotFound();
            
            var customer = _mapper.Map<CustomerDto>(await _customerInterface.GetCustomer(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customerCreate)
        {
            if (customerCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(customerCreate);

            if (! await _customerInterface.CreateCustomer(customerMap))
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
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            if(updatedCustomer is null)
                return BadRequest(ModelState);

            if(id != updatedCustomer.Id)
                return BadRequest(ModelState);

            if (!await _customerInterface.CustomerExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var customerMap = _mapper.Map<Customer>(updatedCustomer);

            if(!await _customerInterface.UpdateCustomer(customerMap)) 
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
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (!await _customerInterface.CustomerExists(id))
                return NotFound();

            var customerToDelete = await _customerInterface.GetCustomer(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _customerInterface.DeleteCustomer(customerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
