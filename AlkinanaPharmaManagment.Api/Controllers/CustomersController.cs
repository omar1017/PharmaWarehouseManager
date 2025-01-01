using AlkinanaPharmaManagment.Application.Customers.Create;
using AlkinanaPharmaManagment.Application.Customers.Delete;
using AlkinanaPharmaManagment.Application.Customers.Get;
using AlkinanaPharmaManagment.Application.Customers.GetById;
using AlkinanaPharmaManagment.Application.Customers.GetByName;
using AlkinanaPharmaManagment.Application.Customers.GetByPharma;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlkinanaPharmaManagment.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ISender sender;

    public CustomersController(ISender sender)
    {
        this.sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetCustomerQuery();

        return Ok(await sender.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetCustomerByIdQuery(id);

        return Ok(await sender.Send(query));
    }

    [HttpGet("n/{customerName}")]
    public async Task<IActionResult> GetByName(string customerName)
    {

        var query = new GetCustomerByNameQuery(customerName);

        return Ok(await sender.Send(query));
    }

    [HttpGet("p/{pharmaName}")]
    public async Task<IActionResult> GetByPharma(string pharmaName)
    {

        var query = new GetCustomersByPharmaQuery(pharmaName);

        return Ok(await sender.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CustomerRequest request)
    {
        var command = new CreateCustomerCommand
        {
            CustomerName = request.customerName,
            Address = request.customerAddress,
            Pharma = request.customerPharma
        };

        return CreatedAtAction(nameof(Get), new {Id = await  sender.Send(command)});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {

        var command = new DeleteCustomerCommand(id);

        await sender.Send(command);
        return NoContent();
    }

}

public record CustomerRequest(string customerName, string customerPharma, string customerAddress);