using Microsoft.AspNetCore.Mvc;
using Transaction.API.Models;
using Transaction.API.Services.Interfaces;

namespace Transaction.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var transactions = await _transactionService.GetAllAsync();
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var transaction = await _transactionService.GetByIdAsync(id);
        if (transaction == null)
            return NotFound();

        return Ok(transaction);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TransactionModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _transactionService.CreateAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _transactionService.DeleteAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}
