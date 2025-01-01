using AlkinanaPharmaManagment.Application.Abstractions.Messaging;
using AlkinanaPharmaManagment.Domain.Entities;
using AlkinanaPharmaManagment.Domain.Repositoryies;
using AlkinanaPharmaManagment.Domain.ValueObject;
using AlkinanaPharmaManagment.Shared.Abstraction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Application.Products.Create
{
    internal sealed class CreateProductCommandHandler(IProductRepository productRepository) : ICommandHandler<CreateProductCommand, ProductId>
    {
        public async Task<Result<ProductId>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.CreateProduct(
                request.Product.name,
                request.Product.image,
                request.Product.companyName,
                request.Product.description,
                request.Product.price,
                request.Product.supplier,
                request.Product.createdBy);


            await productRepository.AddAsync(product);

            await productRepository.SaveChangeAsync();

            return product.ProductId;
        }
    }
}
