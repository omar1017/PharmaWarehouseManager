using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.ValueObject;


namespace AlkinanaPharmaManagment.Application.Products.Update
{
    public sealed record UpdateProductCommand(Product Product) : ICommand<ProductId>;
}
