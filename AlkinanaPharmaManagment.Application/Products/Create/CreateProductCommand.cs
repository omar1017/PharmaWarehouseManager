using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities.Products.ValueObject;
using AlkinanaPharmaManagment.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Create
{
    public record CreateProductCommand(ProductRequest Product) : ICommand<ProductId>;

    public record ProductRequest(ProductName name, ProductImage image, CompanyName companyName, Description description, Price price, Supplier supplier, string createdBy);
}
