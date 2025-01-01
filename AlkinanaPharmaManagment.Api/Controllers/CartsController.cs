using AlkinanaPharmaManagment.Api.Extensions;
using AlkinanaPharmaManagment.Api.Infrastructure;
using AlkinanaPharmaManagment.Application.Carts.Get;
using AlkinanaPharmaManagment.Domain.Entities.Customers;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AlkinanaPharmaManagment.Application.Carts;
using AlkinanaPharmaManagment.Application.Carts.GetById;
using AlkinanaPharmaManagment.Application.Carts.Delete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlkinanaPharmaManagment.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private readonly ISender sender;

    public CartsController(ISender sender)
    {
        this.sender = sender;
    }
    // GET: api/<CartsController>

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetCartByIdQuery(id);
        return Ok(await sender.Send(query));
    } 


    // POST api/<CartsController>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CartRequest request)
    {
        var command = new CreateCartCommand { CustomerId = request.CustomerId, LineItems = request.Items };

        return CreatedAtAction(nameof(Get), new { Id = await sender.Send(command) }, Cart.Create(request.CustomerId));

    }
    

    

    // DELETE api/<CartsController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteCartCommand(id);

        await sender.Send(command);

        return NoContent();
    }
    
}
public record CartRequest(Guid CustomerId, List<LineItem> Items);
