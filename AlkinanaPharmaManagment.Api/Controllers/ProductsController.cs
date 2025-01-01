using AlkinanaPharmaManagment.Application.Products.Create;
using AlkinanaPharmaManagment.Application.Products.Get;
using AlkinanaPharmaManagment.Application.Products.GetByCompany;
using AlkinanaPharmaManagment.Application.Products.GetById;
using AlkinanaPharmaManagment.Application.Products.GetByName;
using AlkinanaPharmaManagment.Application.Products.GetBySupplier;
using AlkinanaPharmaManagment.Application.Products.Update;
using AlkinanaPharmaManagment.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlkinanaPharmaManagment.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender sender;

    public ProductsController(ISender sender)
    {
        this.sender = sender;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetProductsQuery();
        return Ok(await sender.Send(query));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetProductByIdQuery(id);

        return Ok(await sender.Send(query));
    }

    [HttpGet("companies/{companyName}")]
    public async Task<IActionResult> GetByCompanyName(string companyName) {
        var query = new GetProductsByCompanyQuery(companyName);

        return Ok(await sender.Send(query));
    }


    [HttpGet("n/{name}")]
    public async Task<IActionResult> GetByName(string name) {

        var query = new GetProductsByNameQuery(name);

        return Ok(await sender.Send(query));
    }

    [HttpGet("supplier/{supplierName}")]
    public async Task<IActionResult> GetBySupplier(string supplierName) {
        var query = new GetProductsBySupplierQuery(supplierName);

        return Ok(await sender.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductRequest request) {
        var command = new CreateProductCommand
        {
            CompanyName = request.companyName,
            Description = request.description,
            Price = request.price,
            ProductImage = request.productImage,
            ProductName = request.productName,
            Supplier = request.supplier
        };

        return CreatedAtAction(nameof(Get), new {Id = await sender.Send(command)});
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Product request) {

        var command = new UpdateProductCommand
        {
            Product = request
        };

        await sender.Send(command);
        return NoContent();
    }
    
}
public record ProductRequest(string productName, string productImage, string companyName, string description, double price, string supplier);
