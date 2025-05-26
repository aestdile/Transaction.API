using Microsoft.AspNetCore.Mvc;
using Transaction.API.Models;
using Transaction.API.Services;


namespace Transaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericCRUDService<CustomerModel> _customerService;

        public CustomerController(IGenericCRUDService<CustomerModel> customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return NotFound($"Customer with the given id: {id} is not found.");
            }
            else if (id < 0)
            {
                return BadRequest("Wrong Data");
            }

            return Ok(await _customerService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerModel customerModel)
        {
            var createdCustomer = await _customerService.Create(customerModel);
            var routeValues = new { id = createdCustomer.Id };
            return CreatedAtRoute(routeValues, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerModel customerModel)
        {
            var updatedCustomer = await _customerService.Update(id, customerModel);
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteResult = await _customerService.Delete(id);
            if (deleteResult)
                return NoContent();
            else
                return NotFound();
        }
    }
}
