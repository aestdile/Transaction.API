using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transaction.API.DataAccess.Entities;
using Transaction.API.Models;
using Transaction.API.Services;


namespace Transaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IGenericCRUDService<BankAccountModel> _bankAccountService;

        public BankAccountController(IGenericCRUDService<BankAccountModel> bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bankAccountService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return NotFound($"BankAccount with the given id: {id} is not found.");
            }
            else if (id < 0)
            {
                return BadRequest("Wrong Data");
            }

            return Ok(await _bankAccountService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BankAccountModel bankAccountModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Wrong Data");

            var createdBankAccount = await _bankAccountService.Create(bankAccountModel);
            var routeValues = new { id = createdBankAccount.Id };
            return CreatedAtRoute(routeValues, bankAccountModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BankAccountModel bankAccountModel)
        {
            var updateBankAccount = 
                await _bankAccountService.Update(id, bankAccountModel);

            return Ok(updateBankAccount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleteResult = await _bankAccountService.Delete(id);
            if (deleteResult)
                return NoContent();
            else
                return NotFound();
        }
    }
}
